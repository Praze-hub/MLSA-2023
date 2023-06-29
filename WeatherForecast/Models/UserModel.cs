using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}