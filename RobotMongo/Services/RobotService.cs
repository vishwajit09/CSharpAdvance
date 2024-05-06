
using RobotMongo.Database.Models;

using RobotMongo.Database.Interface;
using RobotMongo.Services.Interface;

namespace RobotMongo.Services
{
    public class RobotService : IRobotService
    {
        IRobotRepository _robotRepository;

        public RobotService(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public void SaveRobot(Robot robot)
        {
            _robotRepository.SaveRobot(robot);
        }

        public void SaveRobots(List<Robot> robots)
        {
            _robotRepository.SaveRobots(robots);
        }

        public Robot GetRobotById(string id)
        {
            return _robotRepository.GetRobotById(id);
        }

        public List<Robot> GetRobotsByParameter(string parameter, object value)
        {
            return _robotRepository.GetRobotsByParameter(parameter, value);
        }

        public void DeleteRobotById(string id)
        {
            _robotRepository.DeleteRobotById(id);
        }

        public void UpdateRobot(Robot robot)
        {
            _robotRepository.UpdateRobot(robot);
        }


        public List<Robot> GetAllRobots()
        {
            var robots = _robotRepository.GetAllRobots();
            return robots;
        }
    }
}
