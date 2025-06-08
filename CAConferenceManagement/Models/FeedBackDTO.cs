namespace CAConferenceManagement.Models
{
    public class FeedBackDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int  Rating { get; set; }
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonFullName => $"{PersonName} {PersonSurname}";
    }
}
