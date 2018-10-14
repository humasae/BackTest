namespace WebApiTest.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Professor { get; set; }

        public int RoomNumber { get; set; }

        public virtual Student Student { get; set; }
    }
}