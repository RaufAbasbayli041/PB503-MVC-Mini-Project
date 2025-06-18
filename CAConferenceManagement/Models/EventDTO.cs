using System.ComponentModel.DataAnnotations;
using CAConferenceManagement.Entity;

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
        [Display(Name = "Organizer")]
        public List<int> OrganizerIds { get; set; } = new List<int>();
        public List<OrganizerDTO> Organizers { get; set; } = new();
        public List<EventTypeDTO> EventTypes { get; set; } = new();



    }
}
