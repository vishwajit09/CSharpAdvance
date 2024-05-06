using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RobotMongo.Database;
using RobotMongo.Database.Interface;
using RobotMongo.Database.Models;
using RobotMongo.Services;
using RobotMongo.Services.Interface;

namespace RobotMongo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRobotRepository robotRepository = new RobotRepository();
            IRobotService robotService = new RobotService(robotRepository);

            RobotReaderWriter robotReaderWriter = new RobotReaderWriter();
            StarRobotcs starRobotcs = new StarRobotcs(robotService, robotReaderWriter);
            starRobotcs.Menu();

            //RobotReaderWriter robotReader = new RobotReaderWriter();
            //Robot robot = robotReader.ReadRobotFromJson();


            //RobotRepository robotService = new RobotRepository();

            //robotService.SaveRobot(robot);
            //while (true)
            //{
            //    switch (switch_on)
            //    {
            //        default:
            //    }
            //}

            //// Retrieve robot by ID
            //string robotId = robotReader.ReadRobotFromJson().Id;
            //Robot retrievedRobot = robotService.GetRobotById(robotId);
            //Console.WriteLine($"Retrieved Robot ID: {retrievedRobot.Id}");


            //List<Robot> robots = robotService.GetAllRobots();
            //robotReader.WriteRobotsToFile(robots);

        }


    }
}
