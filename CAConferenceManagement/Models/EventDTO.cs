namespace CAConferenceManagement.Models
{
    public class EventDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string OrganizerFullName => $"{OrganizerName} {OrganizerSurname}";
        public string OrganizerName { get; set; }
        public string OrganizerSurname { get; set; }

        public List<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();



    }
}
