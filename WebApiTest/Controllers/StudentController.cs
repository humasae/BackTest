using System.Collections.Generic;
using System.Web.Http;
using WebApiTest.Filters;
using WebApiTest.Models.Classes;
using WebApiTest.Models.Interfaces;

namespace WebApiTest.Controllers
{
    /// <summary>
    /// customer controller class for testing api
    /// </summary>
    [BasicAuthentication]
    public class StudentController : ApiController
    {
        IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET api/student 
        public IEnumerable<Student> Get()
        {
            return _repository.GetAll();
        }

        // GET api/student/5  
        public IHttpActionResult Get(int id)
        {
            var student = _repository.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        public IHttpActionResult Post(Student student)
        {
            var a = student;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(student);
            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }
    }
}
