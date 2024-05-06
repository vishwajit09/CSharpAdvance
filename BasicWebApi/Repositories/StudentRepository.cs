using BasicWebApi.Model;

namespace BasicWebApi.Repositories
{
    public class StudentRepository
    {
        private List<StudentCourse> _studentCourses = new List<StudentCourse>();

        public StudentRepository()
        {
            _studentCourses.Add(new StudentCourse { Id = Guid.NewGuid(), Name = "Vishwajit", Course = "C#" });
            _studentCourses.Add(new StudentCourse { Id = Guid.NewGuid(), Name = "Tomas", Course = "C#" });
            _studentCourses.Add(new StudentCourse { Id = Guid.NewGuid(), Name = "John", Course = "C#" });
        }

        public List<StudentCourse> GetAll()
        {
            return _studentCourses;
        }

        public StudentCourse GetStudentById(Guid id)
        {
            return _studentCourses.Find(x=>x.Id==id);
        }

        public void Add(StudentCourse studentCourse)
        {
            _studentCourses.Add(studentCourse);
        }

        public bool Update(StudentCourse studentCourse)
        {
            if (studentCourse != null)
            {
                int index = _studentCourses.FindIndex(x => x.Id == studentCourse.Id);
                _studentCourses.RemoveAt(index);
                _studentCourses.Add(studentCourse);
                return true;
            }
            else
            { return false; }
        }

        public bool Delete(Guid id)
        {
            var student = _studentCourses.Find(x => x.Id == id);
            if (student != null)
            {
                _studentCourses.Remove(_studentCourses.Find(x => x.Id == id));
                return true;
            }else { return false; }
        }
    }
}
