using System.Collections.Generic;
using WebApiTest.Models.Classes;

namespace WebApiTest.Models.Interfaces
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();

        Subject GetByID(int id);

        void Add(Subject subject);

        void Delete(Subject subject);

        void Update(Subject subject);
    }
}
