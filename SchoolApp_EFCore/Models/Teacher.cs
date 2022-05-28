using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Teacher : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public ICollection<Group> Groups { get; set; }

        public List<GroupTeacher> TeacherGroups { get; set; }
    }
}
