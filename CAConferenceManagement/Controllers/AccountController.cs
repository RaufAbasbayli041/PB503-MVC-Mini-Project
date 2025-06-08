using CAConferenceManagement.Entity;
using CAConferenceManagement.Helpers.Enum.Role;
using CAConferenceManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Collections.Immutable;

namespace CAConferenceManagement.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }
            var user = await _userManager.FindByEmailAsync(loginDTO.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginDTO.UserNameOrEmail);
            }
           
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                switch (user.Role)
                {
                    case RoleStatus.Admin:
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    case RoleStatus.Teacher:
                        return RedirectToAction("Index", "Home", new { area = "Teacher" });
                    case RoleStatus.Organizer:
                        return RedirectToAction("Index", "Home", new { area = "Organizer" });
                    case RoleStatus.Student:
                        return RedirectToAction("Index", "Home", new { area = "Student" });
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username,email or password.");
                return View(loginDTO);
            }
        }






        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            if (!ModelState.IsValid)
            {
                return View(registerDTO);
            }

            var user1 = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Role = registerDTO.Role,
            };
            var result = await _userManager.CreateAsync(user1, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user1, registerDTO.Role.ToString());
                await _signInManager.SignInAsync(user1, isPersistent: false);
                switch (registerDTO.Role)
                {
                    case RoleStatus.Admin:
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    case RoleStatus.Teacher:
                        return RedirectToAction("Index", "Home", new { area = "Teacher" });
                    case RoleStatus.Organizer:
                        return RedirectToAction("Index", "Home", new { area = "Organizer" });
                    case RoleStatus.Student:
                        return RedirectToAction("Index", "Home", new { area = "Student" });
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerDTO);

        }

    }
}
