using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Models
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

    }
}
