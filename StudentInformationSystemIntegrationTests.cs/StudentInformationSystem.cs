using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Repositories.Interfaces;
using StudentInformationSystem.Services;
using StudentInformationSystem.Services.Interfaces;

namespace StudentInformationSystemIntegrationTests.cs
{
    public class StudentInformationSystem : IDisposable
    {

        private DbContextOptions<StudentInformationContext> _options;
        private StudentInformationContext _context;
        private DepartmentService _departmentService;
        private DepartmentRepository _departmentRepository;
        private StudentRepository _studentRepository;
        private StudentService _studentService;
        private LectureService _leureService;
        private LectureRepository _leureRepository;

        public StudentInformationSystem()
        {
            _options = new DbContextOptionsBuilder<StudentInformationContext>()
                .UseInMemoryDatabase(databaseName: "InMemory").Options;

            _context = new StudentInformationContext(_options);
            _departmentRepository = new DepartmentRepository(_context);
            _departmentService = new DepartmentService(_departmentRepository);
            _studentRepository = new StudentRepository(_context);
            _studentService = new StudentService(_studentRepository);
            _leureRepository = new LectureRepository(_context);
            _leureService = new LectureService(_leureRepository);
            AddDepartment();
        }



        public void AddDepartment()
        {


            List<Lecture> lectures = new List<Lecture>
            {
                new Lecture { Name = "Introduction to Programming" },
                new Lecture { Name = "Physics 101" },
                new Lecture { Name = "Calculus I" }
            };

            List<Student> students = new List<Student>
            {
                new Student { Name = "John Doe" } ,
                new Student { Name = "Jane Smith" },
                new Student { Name = "Alice Johnson"}
            };

            List<Department> departments = new List<Department>
            {
                new Department { Name = "Computer Science" , Lectures = new List<Lecture> { lectures[0], lectures[1] },Students = new List<Student> { students[0], students[1] } },
                new Department { Name = "Physic" , Lectures = new List<Lecture> { lectures[0], lectures[1] },Students = new List<Student> { students[0], students[1] } },
                 new Department { Name = "Calculas" , Lectures = new List<Lecture> { lectures[0], lectures[1] },Students = new List<Student> { students[0], students[1] } }

            };


            //departments[0].Lectures = new List<Lecture> { lectures[0], lectures[1] };
            //departments[1].Lectures = new List<Lecture> { lectures[1] };
            //departments[2].Lectures = new List<Lecture> { lectures[2] };

            //departments[0].Students = new List<Student> { students[0], students[1] };
            //departments[1].Students = new List<Student> { students[1], students[2] };
            //departments[2].Students = new List<Student> { students[0], students[2] };

            _departmentService.CreateDepartment(departments[0]);
            _departmentService.CreateDepartment(departments[1]);
            _departmentService.CreateDepartment(departments[2]);

        }



        [Fact]
        public void DisplayLecturersinDept_DepartmentID_ReturnLectures()
        {
            //Arrange


            List<Lecture> lectures = new List<Lecture>
            {
                new Lecture { Name = "Introduction to Programming" },
                new Lecture { Name = "Physics 101" }
            };

            //department.Students = students;
            //department.Lectures = lectures;



            List<Lecture> expectedLectures = _departmentService.GetLecturesByDepartment(_departmentService.GetDepartmentByName("Computer Science").Id);

            Assert.Equal(expectedLectures[0].Name, lectures[0].Name);
            Assert.Equal(expectedLectures[1].Name, lectures[1].Name);


        }

        [Fact]

        public void CreateLectureandAssignDept_LectureName_LectureAddedToDept()
        {

            var lectureName = "Math 101";

            int[] departmentIds = { 0, 1 };

            List<Department> departmentList = new List<Department>();

            Department department = new Department();

            foreach (var item in departmentIds)
            {
                department = _departmentService.GetDepartmentByID(item);
                if (department is null)
                {


                }
                else
                {
                    departmentList.Add(department);
                }
            }
            if (departmentList.Count > 0)
            {
                _leureService.CreateLectureWithDepartment(lectureName, departmentList);


            }


            Lecture lecture = _leureService.GetlectureById(4);

            Assert.Contains(lectureName, lecture.Name);

        }

        [Fact]
        public void DisplayStudentinDept_DepartmentID_returnStudent()
        {
            //Arrange

            List<Student> students = new List<Student>
            {
                new Student { Name = "John Doe", },
                new Student { Name = "Jane Smith" }
            };

            var id = _departmentService.GetDepartmentByName("Computer Science").Id;

            List<Student> student = _departmentService.GetStudentsByDepartment(id);

            Assert.Equal(student[0].Name, students[0].Name);


        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}