using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTest.Models.Classes;
using WebApiTest.Models.Interfaces;

namespace WebApiTest.Models.Impl
{
    public class StudentRepository : IStudentRepository
    {
        private WebApiTestContext db = new WebApiTestContext();


        public IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public Student GetByID(int id)
        {
            return db.Students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}