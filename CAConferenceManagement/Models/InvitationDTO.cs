using CAConferenceManagement.Entity;
using CAConferenceManagement.Helpers.Enum.InvitationStatus;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MimeKit.Encodings;
using System.Security.Permissions;

namespace CAConferenceManagement.Models
{
    public class InvitationDTO
    {
        public int Id { get; set; }
        public InvitationStatus Status { get; set; }
        public int EventId { get; set; }
		public EventDTO Event { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public Participation Participation { get; set; }

		public string UserFullName => $"{User.Name} {User.Surname}";
		public string EventTitle => Event?.Title ?? "No Event";




	}
}
