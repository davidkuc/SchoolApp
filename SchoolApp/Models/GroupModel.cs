using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Group
    {
        public string Name { get; set; }
        public ICollection<StudentModel> Students { get; set; }

        public Subject Subject { get; set; }
    }
}
