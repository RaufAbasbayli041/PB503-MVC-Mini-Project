using CAConferenceManagement.Entity;
using CAConferenceManagement.Helpers.Enum.Role;
using System.ComponentModel.DataAnnotations;

namespace CAConferenceManagement.Models
{
    public class RegisterDTO
    {

        [Required()]
        [StringLength(250, MinimumLength = 3)]
        public string Name { get; set; }
        [Required()]
        [StringLength(250, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required()]
        [StringLength(250, MinimumLength = 3)]

        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required()]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required()]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public RoleStatus Role { get; set; }

    }
}
