using CAConferenceManagement.Enum.Role;

namespace CAConferenceManagement.Entity
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public RoleStatus Role { get; set; }
        public Invitation Invitation { get; set; }

        public List<FeedBack> FeedBacks { get; set; }


    }
}
