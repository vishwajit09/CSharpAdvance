using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeatherInformation.Dto
{
    public class WeatherResponse
    {
        
        public string city { get; set; }
        
        public string datetime { get; set; }        
        public string resolvedAddress { get; set; }
        public string timezone { get; set; }
        public string? description { get; set; }
        public float tempmax { get; set; }
        public float tempmin { get; set; }
        
    }
}
