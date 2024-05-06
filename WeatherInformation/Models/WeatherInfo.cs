using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WeatherInformation.Dto;

namespace WeatherInformation.Models
{
    public class WeatherInfo
    {
       
        
        public string city { get; set; }
        public string resolvedAddress { get; set; }
        public string timezone { get; set; }
        public string? description { get; set; }
        public float tempmax { get; set; }
        public float tempmin { get; set; }
       
        public string datetime { get; set; }
    }
}
