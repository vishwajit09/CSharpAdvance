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
    public class LectureRepository : ILectureRepository
    {
        private readonly StudentInformationContext _studentInformationContext;

        public LectureRepository(StudentInformationContext studentInformationContext)
        {
            _studentInformationContext = studentInformationContext;

        }

        public void AddLecture(Lecture lecture)
        {
            _studentInformationContext.Lectures.Add(lecture);
            _studentInformationContext.SaveChanges();
        }

        public Lecture GetLectureById(int lectureId)
        {
            return _studentInformationContext.Lectures.FirstOrDefault(x => x.Id == lectureId);
        }

        public void UpdateLecture(Lecture lecture)
        {
            _studentInformationContext.Lectures.Update(lecture);
            _studentInformationContext.SaveChanges();
        }
    }
}
