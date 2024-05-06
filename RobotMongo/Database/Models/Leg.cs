using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo.Database.Models
{
    public class Leg
    {
        public string Material { get; set; }
        public int NumberOfJoints { get; set; }
        public string SizeOfFoot { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
