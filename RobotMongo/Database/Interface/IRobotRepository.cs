using MongoDB.Bson;
using MongoDB.Driver;
using RobotMongo.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo.Database.Interface
{
    public interface IRobotRepository
    {
        public void SaveRobot(Robot robot);

        public void SaveRobots(List<Robot> robots);

        public Robot GetRobotById(string id);

        public List<Robot> GetRobotsByParameter(string parameter, object value);

        public void DeleteRobotById(string id);

        public void UpdateRobot(Robot robot);

        public List<Robot> GetAllRobots();
    }
}
