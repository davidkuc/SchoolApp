using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp2.Models
{
    public class StudentModel
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<GroupModel> Groups { get; set; }
    }
}
