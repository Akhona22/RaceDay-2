namespace RaceDay.API.DTOs
{
    public class CategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;

        public decimal Distance { get; set; }

        public int EventID { get; set; }
    }
}
