using CAConferenceManagement.Entity;
using CAConferenceManagement.Helpers.Enum.Role;

namespace CAConferenceManagement.Models
{
    public class RegisterDTO
    {
        public string UserName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public RoleStatus Role { get; set; } 

    }
}
