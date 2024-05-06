using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories.Interfaces;
using StudentInformationSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public virtual Student GetStudentById(int studentId)
        {
            return _studentRepository.GetStudentById(studentId);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);

        }


    }
}
