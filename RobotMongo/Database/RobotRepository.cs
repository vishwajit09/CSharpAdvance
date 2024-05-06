using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RobotMongo.Database.Interface;
using RobotMongo.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo.Database
{
    public class RobotRepository : IRobotRepository
    {
        private IMongoCollection<Robot> _collection;

        string connectionString = "mongodb+srv://vishwajit:CKHySLfeg4lG17Vz@cluster0.z1ji6je.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        string databaseName = "RobotMango";
        string collectionName = "Robots";

        public RobotRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<Robot>(collectionName);
        }

        public void SaveRobot(Robot robot)
        {
            _collection.InsertOne(robot);
        }

        public void SaveRobots(List<Robot> robots)
        {
            _collection.InsertMany(robots);
        }

        public Robot GetRobotById(string id)
        {
            return _collection.Find(r => r.Id == id).FirstOrDefault();
        }

        public List<Robot> GetRobotsByParameter(string parameter, object value)
        {
            var filter = Builders<Robot>.Filter.Eq(parameter, value);
            return _collection.Find(filter).ToList();
        }

        public void DeleteRobotById(string id)
        {
            _collection.DeleteOne(r => r.Id == id);
        }

        public void UpdateRobot(Robot robot)
        {
            _collection.ReplaceOne(r => r.Id == robot.Id, robot);
        }


        public List<Robot> GetAllRobots()
        {
            var robots = _collection.Find(new BsonDocument()).ToList();
            return robots;
        }
    }
}
