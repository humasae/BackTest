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
    public class SubjectController : ApiController
    {
        ISubjectRepository _subjectRepository;
        IStudentRepository _studentRepository;

        public SubjectController(ISubjectRepository subjectRepository, IStudentRepository studentRepository)
        {
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
        }

        

        // GET api/subject 
        public IEnumerable<Subject> Get()
        {
            return _subjectRepository.GetAll();
        }

        // GET api/subject/5  
        public IHttpActionResult Get(int id)
        {
            var subject = _subjectRepository.GetByID(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        public IHttpActionResult Post(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _studentRepository.GetByID(subject.Student.Id);

            if(student == null)
            {
                return NotFound();
            }

            subject.Student = student;

            _subjectRepository.Add(subject);
            return CreatedAtRoute("DefaultApi", new { id = subject.Id }, subject);
        }

        public IHttpActionResult Put(Subject newSubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldSubject = _subjectRepository.GetByID(newSubject.Id);
            if (oldSubject == null)
            {
                return NotFound();
            }

            _subjectRepository.Update(newSubject);
            return Ok(new { id = newSubject.Id });
        }

        public IHttpActionResult Delete(int id)
        {
            var subject = _subjectRepository.GetByID(id);
            if (subject == null)
            {
                return NotFound();
            }

            _subjectRepository.Delete(subject);

            return Ok();

        }
    }
}
