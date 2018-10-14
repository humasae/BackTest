using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Add(Student student)
        {
            db.Students.Add(student);
            return (db.SaveChanges() >= 0);
        }

        public bool Delete(Student student)
        {
            db.Students.Remove(student);
            return (db.SaveChanges() >= 0);
        }

        public bool Update(Student student)
        {
            using (db)
            {
                var oldStudent = db.Students.FirstOrDefault(s => s.Id == student.Id);

                oldStudent.LastName = student.LastName;
                oldStudent.FirstName = student.FirstName;
                oldStudent.City = student.City;
                oldStudent.SubjectId = student.SubjectId;

                return (db.SaveChanges() >= 0);
            }
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