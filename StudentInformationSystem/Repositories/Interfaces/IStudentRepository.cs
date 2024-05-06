using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudentById(int studentId);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
    }
}
