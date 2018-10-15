using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTest.Models.Classes
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Professor { get; set; }

        public int RoomNumber { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}