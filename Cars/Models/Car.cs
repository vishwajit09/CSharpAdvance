using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Car
    {
        //public Car( string make, string model, int year, string color)
        //{

        //    Make = make;
        //    Model = model;
        //    Year = year;
        //    Color = color;
        //}
       
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Make { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Model { get; set; }

            public int Year { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Color { get; set; }
       
    }
}
