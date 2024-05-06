using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories.Interfaces
{
    public interface ILectureRepository
    {
        Lecture GetLectureById(int lectureId);
        void AddLecture(Lecture lecture);
        void UpdateLecture(Lecture lecture);
    }
}
