using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models.Classes;
using WebApiTest.Models.Interfaces;

namespace WebApiTest.Models.Impl
{
    public class SubjectRepository : ISubjectRepository
    {
        private WebApiTestContext db = new WebApiTestContext();


        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects;
        }

        public Subject GetByID(int id)
        {
            return db.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
        }

        public void Delete(Subject subject)
        {
            db.Subjects.Remove(subject);
            db.SaveChanges();
        }

        public void Update(Subject subject)
        {
            using (db)
            {
                var oldSubject = db.Subjects.FirstOrDefault(s => s.Id == subject.Id);

                oldSubject.Name = subject.Name;
                oldSubject.Professor = subject.Professor;
                oldSubject.RoomNumber = subject.RoomNumber;
                oldSubject.Student = subject.Student;

                db.SaveChanges();
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