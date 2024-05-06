using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Repositories.Interfaces;
using StudentInformationSystem.Services;
using StudentInformationSystem.Services.Interfaces;

namespace StudentInformationSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            StudentInformationContext db = new StudentInformationContext();
            IDepartmentRepository departmentRepository = new DepartmentRepository(db);
            IDepartmentService departmentService = new DepartmentService(departmentRepository);

            ILectureRepository lectureRepository = new LectureRepository(db);
            ILectureService lettureService = new LectureService(lectureRepository);

            IStudentRepository studentRepository = new StudentRepository(db);
            IStudentService studentService = new StudentService(studentRepository);

            StudentInformation studentInformation = new StudentInformation(departmentService, studentService, lettureService);
            studentInformation.Menu();
        }

    }
}

