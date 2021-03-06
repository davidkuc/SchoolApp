using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Group : IEntity
    {
        public string SCode { get; set; }

        public string ActivityForm { get; set; }

        public ICollection<Student> Students { get; set; }

        public List<GroupStudent> StudentGroups { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        public List<GroupTeacher> TeacherGroups { get; set; }

        public int ID { get; set ; }
    }
}
