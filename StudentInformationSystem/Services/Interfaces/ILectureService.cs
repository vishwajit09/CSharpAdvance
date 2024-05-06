using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Interfaces
{
    public interface ILectureService
    {
        Lecture GetlectureById(int id);
        void CreateLecture(Lecture lecture);
        void UpdateLecture(Lecture lecture);

        void CreateLectureWithDepartment(string lectureName, List<Department> department);
    }
}
