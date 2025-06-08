using CAConferenceManagement.Entity;
using CAConferenceManagement.Helpers.Enum.InvitationStatus;
using System.Security.Permissions;

namespace CAConferenceManagement.Models
{
    public class InvitationDTO
    {
        public int Id { get; set; }
        public InvitationStatus Status { get; set; }
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonFullName => $"{PersonName} {PersonSurname}";
        


    }
}
