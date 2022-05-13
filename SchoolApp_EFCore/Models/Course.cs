namespace SchoolApp_EFCore.Models
{
    public class Course : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}