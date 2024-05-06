using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Repositories.Interfaces;
using StudentInformationSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentService)
        {
            _departmentRepository = departmentService;
        }



        public void AddLectureToDepartment(string departmentName, List<Lecture> lectures)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentName); ;
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            foreach (var item in lectures)
            {
                department.Lectures.Add(item);
            }

            _departmentRepository.UpdateDepartment(department);
        }

        public void AddStudentToDepartment(int departmentId, List<Student> students)
        {
            Department department = _departmentRepository.GetDepartmentById(departmentId);

            if (department == null)
            {
                throw new Exception("Department not found");
            }
            else
            {
                foreach (var item in students)
                {

                    department.Students.Add(item);
                }

            }

            _departmentRepository.UpdateDepartment(department);
        }

        public void CreateDepartment(Department department)
        {
            _departmentRepository.AddDepartment(department);
        }

        public List<Lecture> GetLecturesByDepartment(int departmentId)
        {
            return _departmentRepository.GetLecturesByDepartment(departmentId);
        }



        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            return _departmentRepository.GetStudentsByDepartment(departmentId);
        }

        public Student TransferStudentToDepartment(Student student, int newDepartmentId)
        {

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            var newDepartment = _departmentRepository.GetDepartmentById(newDepartmentId);
            if (newDepartment == null)
            {
                throw new Exception("New department not found");
            }

            student.Department = newDepartment;

            // _studentRepository.UpdateStudent(student);
            return student;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            return _departmentRepository.GetDepartmentByName(departmentName);
        }

        public Department GetDepartmentByID(int departmentId)
        {
            return _departmentRepository.GetDepartmentById(departmentId);
        }

        public void AddStudentToDepartmentandLecture(Student student, int departmentId, List<Lecture> lectures)
        {
            var department = _departmentRepository.GetDepartmentById(departmentId);
            department.Lectures = lectures;
            department.Students.Add(student);
            _departmentRepository.UpdateDepartment(department);



        }
    }
}
