using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTest.Models.Classes
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        public int SubjectId { get; set; }
    }
}