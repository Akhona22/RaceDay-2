namespace RaceDay.API.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public decimal Distance { get; set; }

        public int EventID { get; set; }
    }
}
