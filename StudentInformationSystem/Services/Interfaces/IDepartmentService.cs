using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Interfaces
{
    public interface IDepartmentService
    {
        void CreateDepartment(Department department);
        public void AddLectureToDepartment(string departmentName, List<Lecture> lecture);
        public void AddStudentToDepartment(int departmentId, List<Student> students);
        List<Student> GetStudentsByDepartment(int departmentId);
        List<Lecture> GetLecturesByDepartment(int departmentId);
        Student TransferStudentToDepartment(Student student, int newDepartmentId);

        Department GetDepartmentByName(string departmentName);
        Department GetDepartmentByID(int departmentId);

        public void AddStudentToDepartmentandLecture(Student student, int departmentId, List<Lecture> lectures);
    }
}
