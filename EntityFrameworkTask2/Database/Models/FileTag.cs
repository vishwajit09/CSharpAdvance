using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask2.Database.Models
{
    public class FileTag
    {

        public int FileId { get; set; }
        public FileInfomation FileInfomation { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
