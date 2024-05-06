using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    public class Lecture
    {
        public int Id { get; set; }


        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }
        public List<Department>? Departments { get; set; } = new List<Department>();
        public List<Student>? Students { get; set; } = new List<Student>();

    }
}
