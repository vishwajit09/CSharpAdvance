using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Department GetDepartmentById(int departmentId);
        void AddDepartment(Department department);
        void AddStudentToDepartment(int departmentId, Student student);
        void AddLectureToDepartment(int departmentId, Lecture lecture);
        List<Student> GetStudentsByDepartment(int departmentId);
        List<Lecture> GetLecturesByDepartment(int departmentId);
        void UpdateDepartment(Department department);

        Department GetDepartmentByName(string departmentName);
    }
}
