using System.Collections.Generic;

namespace WebApiTest.Models.Classes
{
    public class SubjectResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Professor { get; set; }

        public int RoomNumber { get; set; }

        public ICollection<string> Students { get; set; }

    }
}