using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Models
{
    public class EventTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int EventId { get; set; }
        public EventDTO Event { get; set; }


    }
}
