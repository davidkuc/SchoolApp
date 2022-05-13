using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class TeacherSubjects
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
