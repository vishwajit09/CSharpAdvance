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
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _repository;

        public LectureService(ILectureRepository repository)
        {
            _repository = repository;
        }

        public void CreateLectureWithDepartment(string lectureName, List<Department> department)
        {
            var lecture = new Lecture { Name = lectureName };

            foreach (var departmentId in department)
            {

                if (department != null)
                {
                    lecture.Departments.Add(departmentId);
                }
            }

            _repository.AddLecture(lecture);
        }

        public void UpdateLecture(Lecture lecture)
        {
            _repository.UpdateLecture(lecture);
        }

        //public void GetLecturerbyName(Lecture lecture)
        //{
        //    return _repository.GetLectureByName(lecture.Name);
        //}

        public Lecture GetlectureById(int lectureId)
        {
            return _repository.GetLectureById(lectureId);
        }

        public void CreateLecture(Lecture lecture)
        {
            _repository.AddLecture(lecture);
        }
    }
}
