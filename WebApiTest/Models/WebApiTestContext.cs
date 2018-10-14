using System.Data.Entity;

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