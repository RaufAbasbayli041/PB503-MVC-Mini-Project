using CAConferenceManagement.Helpers.Enum.Role;

namespace CAConferenceManagement.Models
{
    public class LoginDTO
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public RoleStatus Role { get; set; }
    }
}
