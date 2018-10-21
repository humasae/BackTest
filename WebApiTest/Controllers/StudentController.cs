using AutoMapper;
using System;
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
        public IEnumerable<StudentResponse> Get()
        {
            var students = _repository.GetAll();
            var response = Mapper.Map<IEnumerable<Student>,IEnumerable<StudentResponse>>(students);

            return response;
        }

        // GET api/student/5  
        public IHttpActionResult Get(int id)
        {
            var student = _repository.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }

            var response = Mapper.Map<Student, StudentResponse>(student);

            return Ok(response);
        }

        public IHttpActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repository.Add(student))
            {
                throw new Exception($"Adding student failed on save.");
            }

            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != newStudent.Id)
            {
                return BadRequest();
            }

            var oldStudent = _repository.GetByID(id);
            if (oldStudent == null)
            {
                return NotFound();
            }

            if (!_repository.Update(newStudent))
            {
                throw new Exception($"Updating student {newStudent.Id} failed on save.");
            }

            return Ok(newStudent);
        }

        public IHttpActionResult Delete(int id)
        {
            var student = _repository.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }

            if (!_repository.Delete(student))
            {
                throw new Exception($"Deleting student {student.Id} failed on save.");
            }

            return Ok();

        }
    }
}
