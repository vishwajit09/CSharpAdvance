using BasicWebApi.Model;
using BasicWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCourseController : ControllerBase
    {
        static readonly StudentRepository _studentRepository = new StudentRepository();

        private readonly ILogger<StudentCourseController> _logger;

        public StudentCourseController(ILogger<StudentCourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StudentCourse> GetAllStudent()
        {
            return _studentRepository.GetAll();
        }

        [HttpPost]
        public void Post(StudentCourse studentCourse)
        {

            _studentRepository.Add(studentCourse);
        }

        [HttpPut]
        public void Put(StudentCourse studentCourse)
        {
            _studentRepository.Update(studentCourse);
        }

        [HttpDelete]

        public void Delete(Guid StudentId)
        {
            _studentRepository.Delete(StudentId);
        }

        [HttpGet("GetStudentById/{id}")]
        //[ActionName("GetStudentById")]
        //[Route("[Controller]/GetStudentById/{id}")]

        public StudentCourse Get(Guid id)
        {
            return _studentRepository.GetStudentById(id);
        }
    }
}
