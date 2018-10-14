using System.Data.Entity;
using WebApiTest.Models.Classes;

namespace WebApiTest.Models
{
    public class WebApiTestContext : DbContext
    {
        public WebApiTestContext() : base("WebApiTestContext")
        {
        }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}