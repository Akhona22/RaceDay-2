namespace RaceDay.API.DTOs
{
    public class EventDto
    {
        public string EventName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }

        public string Location { get; set; } = string.Empty;

        public decimal Distance { get; set; }

        public int EventTypeID { get; set; }

        public int OrganiserID { get; set; }
    }
}
