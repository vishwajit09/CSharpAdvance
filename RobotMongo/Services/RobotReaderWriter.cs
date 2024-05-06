using MongoDB.Bson;
using Newtonsoft.Json;
using RobotMongo.Database.Models;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo.Services
{
    public class RobotReaderWriter
    {
        // Json file path
        private string filePath = "files/robots.json";
        private string outfile = @"..\..\..\Outputfiles\";
        string dateTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        public List<Robot> ReadRobotFromJson()
        {
            // Read data from Json file and create robot object
            string json = File.ReadAllText(filePath);
            List<Robot> robots = JsonConvert.DeserializeObject<List<Robot>>(json);
            return robots;
        }

        public void WriteRobotsToFile(List<Robot> robots)
        {
            string json = JsonConvert.SerializeObject(robots, Formatting.Indented);
            File.WriteAllText(outfile + dateTime + ".json", json);
            Console.WriteLine($"Robots written to file: {outfile + dateTime}");
        }

    }
}
