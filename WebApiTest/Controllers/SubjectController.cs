using AutoMapper;
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

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        // GET api/subject 
        public IEnumerable<SubjectResponse> Get()
        {
            var subjects = _subjectRepository.GetAll();
            var response = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectResponse>>(subjects);
            return response;

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

            _subjectRepository.Add(subject);
            return CreatedAtRoute("DefaultApi", new { id = subject.Id }, subject);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Subject newSubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newSubject.Id)
            {
                return BadRequest();
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
