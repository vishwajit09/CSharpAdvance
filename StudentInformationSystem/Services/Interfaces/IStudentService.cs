using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Interfaces
{
    public interface IStudentService
    {
        Student GetStudentById(int studentId);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
    }
}
