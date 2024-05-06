using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo.Database.Models
{
    public class Robot
    {
        public string Id { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Leg> Legs { get; set; }
        public Torso Torso { get; set; }
        public HeadType Head { get; set; }



    }
}
