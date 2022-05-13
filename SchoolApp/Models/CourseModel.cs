using SchoolApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class CourseModel
    {
        public string Name { get; set; }

        public int NoOfStudents { get; set; }

        public ICollection<GroupModel> Groups { get; set; }

        public ICollection<Subject> Subjects{ get; set; }
    }
}
