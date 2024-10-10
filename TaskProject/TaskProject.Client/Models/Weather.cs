using System.ComponentModel.DataAnnotations;

namespace TaskProject.Client.Models
{
    public class Weather
    {
        [Key]
        public int WId { get; set; }
        public int CityId { get; set; }
        public string Condition { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
