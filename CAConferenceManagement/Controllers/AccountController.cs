using CAConferenceManagement.EmailOperations.Interface;
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
        private readonly IEmailSenderOpt _emailSender;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IEmailSenderOpt emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
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
                Name = registerDTO.Name,
                Surname = registerDTO.Surname
            };
            var result = await _userManager.CreateAsync(user1, registerDTO.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user1, isPersistent: false);
                await _userManager.AddToRoleAsync(user1, registerDTO.Role.ToString());
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user1);

                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user1.Id, token = token }, protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(user1.Email, "Confirm your email", $"Please confirm your account by clicking this link: <a href='{confirmationLink}'>link</a>");
                TempData["SuccessMessage"] = "Registration successful. Please check your email to confirm your account.";

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    ModelState.AddModelError("", "Registration failed. Please try again.");
                }
            }

            return View(registerDTO);
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
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or email.");
                return View(loginDTO);
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Email not confirmed. Please check your email for confirmation link.");
                return View(loginDTO);
            }


            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);


                if (roles.Contains(RoleStatus.Admin.ToString()))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (roles.Contains(RoleStatus.Teacher.ToString()))
                {
                    return RedirectToAction("Index", "Home", new { area = "Teacher" });
                }
                else if (roles.Contains(RoleStatus.Student.ToString()))
                {
                    return RedirectToAction("Index", "Home", new { area = "Student" });
                }
                else if (roles.Contains(RoleStatus.Organizer.ToString()))
                {
                    return RedirectToAction("Index", "Home", new { area = "Organizer" });
                    // raufka@code.edu.az   mail 
                    // Or123456!    parol
                }
                else
                {
                    ModelState.AddModelError("", "Роль пользователя не распознана.");
                    return View(loginDTO);
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid username,email or password.");
                return View(loginDTO);
            }


        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid email confirmation link.");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Email confirmed successfully. You can now log in.";
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Email confirmation failed. Please try again.");
                return View();
            }

        }


    }
}