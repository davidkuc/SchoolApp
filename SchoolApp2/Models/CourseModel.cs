using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp2.Models
{
    public class CourseModel
    {
        public string Name { get; set; }

        public int NoOfStudents { get; set; }

        public ICollection<GroupModel> Groups { get; set; }

        public ICollection<SubjectModel> Subjects { get; set; }
    }
}
