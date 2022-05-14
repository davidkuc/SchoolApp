using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp2.Models
{

    public class GroupModel
    {
        public string Name { get; set; }
        public ICollection<StudentModel> Students { get; set; }

        public Subject Subject { get; set; }
    }
}
