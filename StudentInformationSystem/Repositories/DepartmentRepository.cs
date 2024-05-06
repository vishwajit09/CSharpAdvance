using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly StudentInformationContext _studentInformationContext;

        public DepartmentRepository(StudentInformationContext studentInformationContext)
        {
            _studentInformationContext = studentInformationContext;
        }

        public void AddDepartment(Department department)
        {
            _studentInformationContext.Departments.Add(department);
            _studentInformationContext.SaveChanges();
        }



        public void AddLectureToDepartment(int departmentId, Lecture lecture)
        {
            Department department = _studentInformationContext.Departments.FirstOrDefault(x => x.Id == departmentId);
            department.Lectures.Add(lecture);
            UpdateDepartment(department);

        }

        public void AddStudentToDepartment(int departmentId, Student student)
        {
            Department department = _studentInformationContext.Departments.FirstOrDefault(x => x.Id == departmentId);
            department.Students.Add(student);
            UpdateDepartment(department);
        }
        public Department GetDepartmentByName(string departmentName)
        {
            return _studentInformationContext.Departments.FirstOrDefault(x => x.Name == departmentName);

        }
        public Department GetDepartmentById(int departmentId)
        {
            return _studentInformationContext.Departments.FirstOrDefault(x => x.Id == departmentId);
        }

        public List<Lecture> GetLecturesByDepartment(int departmentId)
        {
            var lectures = _studentInformationContext.Departments.Include(Lecture => Lecture.Lectures).FirstOrDefault(x => x.Id == departmentId).Lectures;
            return lectures;
        }

        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            var student = _studentInformationContext.Departments.Include(Student => Student.Students).FirstOrDefault(x => x.Id == departmentId).Students;
            return student;
        }

        public void UpdateDepartment(Department department)
        {
            _studentInformationContext.Update(department);
            _studentInformationContext.SaveChanges();
        }

    }
}
