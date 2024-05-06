using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask2.Database.Models
{
    public class FileInfomation
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string FullPath { get; set; }

        [ForeignKey("Folder")]
        public int? FolderId { get; set; }
        public Folder Folder { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
