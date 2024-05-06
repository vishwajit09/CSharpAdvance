using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask2.Database.Models
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FileInfomation>? FileInfomations { get; set; }
    }
}
