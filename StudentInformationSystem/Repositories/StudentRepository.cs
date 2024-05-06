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
    public class StudentRepository : IStudentRepository
    {

        private readonly StudentInformationContext _studentInformationContext;

        public StudentRepository(StudentInformationContext studentInformationContext)
        {
            _studentInformationContext = studentInformationContext;
        }

        public void AddStudent(Student student)
        {
            _studentInformationContext.Students.Add(student);
            _studentInformationContext.SaveChanges();
        }

        public Student GetStudentById(int studentId)
        {
            return _studentInformationContext.Students.Include(Lecture => Lecture.Lectures).FirstOrDefault(x => x.Id == studentId);
        }

        public void UpdateStudent(Student student)
        {
            _studentInformationContext.Students.Update(student);
            _studentInformationContext.SaveChanges();
        }
    }
}

