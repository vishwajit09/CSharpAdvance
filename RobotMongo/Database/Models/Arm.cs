using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo.Database.Models
{
    public class Arm
    {
        public string Material { get; set; }
        public int NumberOfJoints { get; set; }
        public int NumberOfFingers { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
