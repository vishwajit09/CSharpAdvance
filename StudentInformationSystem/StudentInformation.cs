using StudentInformationSystem.Models;
using StudentInformationSystem.Presentation;
using StudentInformationSystem.Repositories.Interfaces;
using StudentInformationSystem.Services;
using StudentInformationSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem
{

    public class StudentInformation
    {


        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly ILectureService _lectureService;

        public StudentInformation(IDepartmentService departmentService, IStudentService studentService, ILectureService lectureService)
        {
            _departmentService = departmentService;
            _studentService = studentService;
            _lectureService = lectureService;
        }

        public void Menu()
        {
            while (true)
            {

                Screen.ShowMenu1();
                switch (GetSelection())
                {
                    case 1:
                        CreateDepartment();
                        break;
                    case 2:
                        AddStudentToDept();
                        break;
                    case 3:
                        AddLectureToDept();
                        break;
                    case 4:
                        CreateLectureandAssignDept();
                        break;
                    case 5:
                        CreateStudentandAssignDeptandLecturer();
                        break;
                    case 6:
                        TransferStudent();
                        break;
                    case 7:
                        DisplayStudentinDept();
                        break;
                    case 8:
                        DisplayLecturersinDept();
                        break;
                    case 9:
                        DisplayLecturersByStudent();
                        break;
                    case 10:
                        AddStudentToLecture();
                        break;
                    case 11:
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


        void CreateDepartment()
        {
            //List<Lecture> lectures = new List<Lecture>
            //{ new Lecture{ Name = "Test1"} ,new Lecture { Name = "Test2"} };

            //List<Student> students = new List<Student> { new Student { Name = "Vish" }, new Student { Name = "Vis1" } };




            Console.WriteLine("Enter department name:");
            var departmentName = Console.ReadLine();

            Console.WriteLine("Enter Students Name you want to add to department :Enter done when finished");
            string name = string.Empty;
            List<Student> students = new List<Student>();
            while ((name = Console.ReadLine()) != "done")
            {
                students.Add(new Student { Name = name });
            }

            name = string.Empty;

            Console.WriteLine("Enter Lecture Name you want to add to department :Enter done when finished");

            List<Lecture> lectures = new List<Lecture>();
            while ((name = Console.ReadLine()) != "done")
            {
                lectures.Add(new Lecture { Name = name });
            }

            Department newDepartment = new Department { Name = departmentName, Students = students, Lectures = lectures };

            _departmentService.CreateDepartment(newDepartment);




        }



        void AddStudentToDept()
        {
            Console.WriteLine("Enter department Name:");
            string deptName = Console.ReadLine();
            Department department = _departmentService.GetDepartmentByName(deptName);
            if (department is null)
            {
                Console.WriteLine("Invalid Department");
            }
            else
            {
                //Console.WriteLine("1 .Enter Student from Database using ID");
                //Console.WriteLine("1 .Enter Department from Database using ID");

                List<Student> students = new List<Student>();
                Console.WriteLine("Enter student ID to add (comma-separated):");
                var studentIdsInput = Console.ReadLine();
                var studentIds = ParseIds(studentIdsInput);

                foreach (var item in studentIds)
                {
                    Student student = _studentService.GetStudentById(item);
                    if (student is null)
                    {

                    }
                    else
                    {
                        students.Add(student);
                    }

                }
                _departmentService.AddStudentToDepartment(department.Id, students);

                Console.WriteLine("Students added to the department successfully.");
            }


        }

        public void AddLectureToDept()
        {
            Console.WriteLine("Enter department Name:");
            string deptName = Console.ReadLine();
            Department department = _departmentService.GetDepartmentByName(deptName);
            if (department is null)
            {
                Console.WriteLine("Invalid Department");
            }
            else
            {
                List<Lecture> lectures = new List<Lecture>();
                Console.WriteLine("Enter Lecture ID to add (comma-separated):");
                var lectureIdsInput = Console.ReadLine();
                var lectureIds = ParseIds(lectureIdsInput);

                foreach (var item in lectureIds)
                {
                    Lecture lecture = _lectureService.GetlectureById(item);
                    if (lecture is null)
                    {
                        Console.WriteLine($" Lecture Id not present in table{lecture}");

                    }
                    else
                    {
                        lectures.Add(lecture);
                    }

                }
                if (lectures.Count > 0)
                {
                    _departmentService.AddLectureToDepartment(deptName, lectures);

                    Console.WriteLine("Students added to the department successfully.");
                }
            }
        }

        public void CreateLectureandAssignDept()
        {
            Console.WriteLine("Enter lecture Name:");
            var lectureName = Console.ReadLine();

            Console.WriteLine("Enter department IDs to assign (comma-separated):");
            var departmentIdsInput = Console.ReadLine();
            var departmentIds = ParseIds(departmentIdsInput);

            List<Department> departmentList = new List<Department>();

            Department department = new Department();

            foreach (var item in departmentIds)
            {
                department = _departmentService.GetDepartmentByID(item);
                if (department is null)
                {
                    Console.WriteLine($" Department Id not present in table{department}");

                }
                else
                {
                    departmentList.Add(department);
                }
            }
            if (departmentList.Count > 0)
            {
                _lectureService.CreateLectureWithDepartment(lectureName, departmentList);

                Console.WriteLine("Lecture created and assigned to departments successfully.");
            }
        }

        void CreateStudentandAssignDeptandLecturer()
        {
            Console.WriteLine("Enter student name:");
            var studentName = Console.ReadLine();

            Student student = new Student { Name = studentName };
            // _studentService.CreateStudent(student);

            Console.WriteLine("Enter department ID to assign:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }

            Console.WriteLine("Enter lecture IDs to assign (comma-separated):");
            var lectureIdsInput = Console.ReadLine();
            var lectureIds = ParseIds(lectureIdsInput);

            List<Lecture> lectures = new List<Lecture>();
            foreach (var item in lectureIds)
            {
                Lecture lecture = _lectureService.GetlectureById(item);
                if (lecture is null)
                {
                    Console.WriteLine($"Lecture Id not found{lecture}");
                }
                else
                {
                    lectures.Add(lecture);
                }

            }

            student.Lectures = lectures;
            student.Department = _departmentService.GetDepartmentByID(departmentId);
            //_departmentService.AddStudentToDepartmentandLecture(student, departmentId, lectures);
            _studentService.CreateStudent(student);
            Console.WriteLine("Lecture created and assigned to department successfully.");
        }

        public void TransferStudent()
        {
            Console.WriteLine("Enter student ID:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }

            Console.WriteLine("Enter new department ID:");
            if (!int.TryParse(Console.ReadLine(), out int newDepartmentId))
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }
            Student student = _studentService.GetStudentById(studentId);

            if (student is not null)
            {
                student = _departmentService.TransferStudentToDepartment(student, newDepartmentId);
                student.Lectures.RemoveAll(x => x.Name == student.Name);

                Console.WriteLine("Enter lecture IDs to assign (comma-separated):");
                var lectureIdsInput = Console.ReadLine();
                var lectureIds = ParseIds(lectureIdsInput);
                //   DisplayLecturersinDept();

                List<Lecture> lectures = new List<Lecture>();

                foreach (var item in lectureIds)
                {
                    Lecture lecture = _lectureService.GetlectureById(item);
                    if (lecture is null)
                    {
                        Console.WriteLine($"Lecture Id not found{lecture}");
                    }
                    else
                    {
                        lectures.Add(lecture);
                    }



                }
                student.Lectures = lectures;

                _studentService.UpdateStudent(student);

                Console.WriteLine("Student transferred to the new department successfully.");
            }
            else
            {
                Console.WriteLine("Invalid student ID");
            }

        }

        void DisplayStudentinDept()
        {
            Console.WriteLine("Enter department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }
            Department department = _departmentService.GetDepartmentByID(departmentId);

            if (department == null)
            {
                Console.WriteLine("Wrong Department ID");
            }
            else
            {

                var students = _departmentService.GetStudentsByDepartment(departmentId);
                Console.WriteLine($"Students in the department:{department.Name}");
                foreach (var student in students)
                {
                    Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                }
            }
        }

        void DisplayLecturersinDept()
        {
            Console.WriteLine("Enter department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }
            Department department = _departmentService.GetDepartmentByID(departmentId);

            if (department == null)
            {
                Console.WriteLine("Wrong Department ID");
            }
            else
            {

                var lectures = _departmentService.GetLecturesByDepartment(departmentId);
                Console.WriteLine($"Lectures in the department:{department.Name}");
                foreach (var lecture in lectures)
                {
                    Console.WriteLine($"Lecture ID: {lecture.Id}, Title: {lecture.Name}");
                }
            }
        }

        public void DisplayLecturersByStudent()
        {
            Console.WriteLine("Enter student ID:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }


            Student student = _studentService.GetStudentById(studentId);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            Console.WriteLine($"Lectures by Student '{student.Name}':");
            foreach (var lecture in student.Lectures)
            {
                Console.WriteLine(lecture.Name);
            }

        }


        void AddStudentToLecture()
        {
            Console.WriteLine("Enter Lecture ID:");
            if (!int.TryParse(Console.ReadLine(), out int lectureId))
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }


            Lecture lecture = _lectureService.GetlectureById(lectureId);
            if (lecture == null)
            {
                throw new Exception("lecture not found");
            }
            else
            {
                List<Student> students = new List<Student>();
                Console.WriteLine("Enter student ID to add (comma-separated):");
                var studentIdsInput = Console.ReadLine();
                var studentIds = ParseIds(studentIdsInput);

                foreach (var item in studentIds)
                {
                    Student student = _studentService.GetStudentById(item);
                    if (student is null)
                    {

                    }
                    else
                    {
                        students.Add(student);
                    }

                }
                lecture.Students = students;
                _lectureService.UpdateLecture(lecture);
            }


        }

        static List<int> ParseIds(string input)
        {
            var ids = new List<int>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var idStrings = input.Split(',');
                foreach (var idString in idStrings)
                {
                    if (int.TryParse(idString.Trim(), out int id))
                    {
                        ids.Add(id);
                    }
                }
            }
            return ids;
        }


    }
}
