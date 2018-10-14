using System.Collections.Generic;
using WebApiTest.Models.Classes;

namespace WebApiTest.Models.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student GetByID(int id);

        void Add(Student student);
    }
}
