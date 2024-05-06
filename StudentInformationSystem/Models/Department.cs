using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }
        public List<Student>? Students { get; set; } = new List<Student>();
        public List<Lecture>? Lectures { get; set; } = new List<Lecture>();
    }

}
