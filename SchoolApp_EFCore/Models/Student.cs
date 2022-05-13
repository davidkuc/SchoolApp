using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Student : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string CourseName { get; set; }

        public int CourseID { get; set; }

        public Course Course { get; set; }

        public string DateOfBirth { get; set; }

        public int Year { get; set; }

        public ICollection<StudentGroups> StudentGroups { get; set; }
    }
}
