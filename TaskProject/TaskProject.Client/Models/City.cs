using System.ComponentModel.DataAnnotations;

namespace TaskProject.Client.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "City Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } 
        public string Population { get; set; }
        public string Type { get; set; } 



    }
}