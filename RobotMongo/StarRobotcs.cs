using RobotMongo.Database;
using RobotMongo.Database.Interface;
using RobotMongo.Database.Models;
using RobotMongo.Services;
using RobotMongo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo
{
    public class StarRobotcs
    {

        private readonly IRobotService _robotService;
        private readonly RobotReaderWriter _robotReaderWriter;

        public StarRobotcs(IRobotService robotService, RobotReaderWriter robotReaderWriter)
        {
            _robotService = robotService;
            _robotReaderWriter = robotReaderWriter;
        }

        public void Menu()
        {
            while (true)
            {

                Screen.ShowMenu1();
                switch (GetSelection())
                {
                    case 1:
                        CreateRobot();
                        break;
                    case 2:
                        SaveListOfRobot();
                        break;
                    case 3:
                        FindRobotbyID();
                        break;
                    case 4:
                        FindRobotByParameter();
                        break;
                    case 5:
                        DeleteRobot();
                        break;
                    case 6:
                        ModifyRobot();
                        break;
                    case 7:
                        WriteToFile();
                        break;
                    case 8:
                        Console.WriteLine("You have succesfully logout.");
                        Environment.Exit(1);
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Invalid Option Entered.");
                        break;


                }
                Console.ReadKey();

            }

        }


        public int GetSelection()
        {
            bool valid = false;
            int input = 0;

            while (!valid)
            {
                Console.Write($"Enter your option: ");

                valid = int.TryParse(Console.ReadLine(), out input);
                if (!valid)
                    Console.WriteLine("Invalid input. Try again.");
            }
            return input;

        }

        public void FindRobotbyID()
        {

            Console.WriteLine("Enter Robot Id");
            string id = Console.ReadLine();
            Robot robot = _robotService.GetRobotById(id);

            Display(robot);

        }

        public void FindRobotByParameter()
        {
            Console.WriteLine("Enter the paramenter name");
            string parameter = Console.ReadLine();

            Console.WriteLine($"Enter the {parameter} value");
            string value = Console.ReadLine();
            List<Robot> robots = _robotService.GetRobotsByParameter(parameter, value);
            foreach (var item in robots)
            {
                Display(item);
            }
        }

        public void DeleteRobot()
        {
            Console.WriteLine("Enter the robot Id you want to delete");
            string id = Console.ReadLine();
            _robotService.DeleteRobotById(id);
        }

        public void ModifyRobot()
        {
            Console.WriteLine("Enter the robot Id you want to modify");
            string id = Console.ReadLine();
            Robot robot = _robotService.GetRobotById(id);
            Display(robot);
            Console.WriteLine("Enter the parameter you want to modify");
            switch (Console.ReadLine())
            {
                case "Head":
                    Console.WriteLine("Enter what type of head you want");
                    string head = Console.ReadLine();
                    if (head == "Optimus")
                    {
                        robot.Head = HeadType.Optimus;
                    }
                    else if (head == "DarkVader")
                    {
                        robot.Head = HeadType.DarkVader;
                    }
                    else { robot.Head = HeadType.IronMan; }
                    break;
                default:
                    break;
            }


            _robotService.UpdateRobot(robot);
        }

        public void SaveListOfRobot()
        {

            List<Robot> robots = _robotReaderWriter.ReadRobotFromJson();
            if (robots != null)
            {
                _robotService.SaveRobots(robots);
            }
        }

        public void WriteToFile()
        {

            _robotReaderWriter.WriteRobotsToFile(_robotService.GetAllRobots());
        }

        public void CreateRobot()
        {
            Robot robot = new Robot();

            // Get user details for the Robot
            Console.WriteLine("Enter Robot ID:");
            robot.Id = Console.ReadLine();

            // Get details for Arms
            robot.Arms = new List<Arm>();
            for (int i = 1; i <= 2; i++)
            {
                Arm arm = new Arm();
                Console.WriteLine($"Enter details for Arm {i}:");
                Console.Write("Material: ");
                arm.Material = Console.ReadLine();
                Console.Write("Number of Joints: ");
                arm.NumberOfJoints = int.Parse(Console.ReadLine());
                Console.Write("Number of Fingers: ");
                arm.NumberOfFingers = int.Parse(Console.ReadLine());
                robot.Arms.Add(arm);
            }

            // Get details for Legs
            robot.Legs = new List<Leg>();
            for (int i = 1; i <= 2; i++)
            {
                Leg leg = new Leg();
                Console.WriteLine($"Enter details for Leg {i}:");
                Console.Write("Material: ");
                leg.Material = Console.ReadLine();
                Console.Write("Number of Joints: ");
                leg.NumberOfJoints = int.Parse(Console.ReadLine());
                Console.Write("Size of Foot: ");
                leg.SizeOfFoot = Console.ReadLine();
                robot.Legs.Add(leg);
            }

            // Get details for Torso
            robot.Torso = new Torso();
            Console.WriteLine("Enter details for Torso:");
            Console.Write("Chest Measurements: ");
            robot.Torso.ChestMeasurements = double.Parse(Console.ReadLine());
            Console.Write("Waist Measurements: ");
            robot.Torso.WaistMeasurements = double.Parse(Console.ReadLine());

            // Get details for Head
            Console.WriteLine("Enter Head Type (DarkVader, IronMan, Bumbulbee, Optimus):");
            robot.Head = (HeadType)Enum.Parse(typeof(HeadType), Console.ReadLine());

            _robotService.SaveRobot(robot);

        }

        public void Display(Robot robot)
        {
            Console.WriteLine("Robot Model:");
            Console.WriteLine($"  • Id: {robot.Id}");
            Console.WriteLine("-----------------");

            Console.WriteLine("  • Arms:");
            foreach (var arm in robot.Arms)
            {
                Console.WriteLine($"      ○ Material: {arm.Material}");
                Console.WriteLine($"      ○ NumberOfJoints: {arm.NumberOfJoints}");
                Console.WriteLine($"      ○ NumberOfFingers: {arm.NumberOfFingers}");
                Console.WriteLine("       -----------------");
            }

            Console.WriteLine("  •Legs:");
            foreach (var leg in robot.Legs)
            {
                Console.WriteLine($"      ○ Material: {leg.Material}");
                Console.WriteLine($"      ○ NumberOfJoints: {leg.NumberOfJoints}");
                Console.WriteLine($"      ○ SizeOfFoot: {leg.SizeOfFoot}");
                Console.WriteLine("       -----------------");
            }

            Console.WriteLine("  • Torso:");
            Console.WriteLine($"      ○ ChestMeasurements: {robot.Torso.ChestMeasurements}");
            Console.WriteLine($"      ○ WaistMeasurements: {robot.Torso.WaistMeasurements}");
            Console.WriteLine("-----------------");
            Console.WriteLine("  • Head:");
            Console.WriteLine($"      ○ Type: {robot.Head}");
        }

    }
}
