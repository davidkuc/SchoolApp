using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class GroupTeacher
    {
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public string GroupId { get; set; }
        public Group Group { get; set; }
    }
}
