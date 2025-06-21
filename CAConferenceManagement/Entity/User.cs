using CAConferenceManagement.Helpers.Enum.Role;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CAConferenceManagement.Entity
{
    public class User : IdentityUser
    {
        [Display(Name ="UserName")]
        public string Name { get; set; }
        public string Surname { get; set; }
        

       
       // public RoleStatus Role { get; set; }
        public List<Invitation> Invitation { get; set; } = new List<Invitation>();

        public List<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();


    }
}
