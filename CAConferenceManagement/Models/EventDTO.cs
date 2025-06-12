using System.ComponentModel.DataAnnotations;

namespace CAConferenceManagement.Models
{
    public class EventDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; } 
        public LocationDTO Location { get; set; }

        [Required]
        [Display(Name ="Organizer")]
        public int OrganizerId { get; set; }
        public OrganizerDTO Organizer { get; set; }
        public List<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();



    }
}
