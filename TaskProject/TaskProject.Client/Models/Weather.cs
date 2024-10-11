using System.ComponentModel.DataAnnotations;

namespace TaskProject.Client.Models
{
    public class Weather
    {
        [Key]
        public int WId { get; set; }
        public int CityId { get; set; }
        public string Condition { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
