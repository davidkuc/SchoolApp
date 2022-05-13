using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Group
    {
        public string Code { get; set; }

        public string Subject { get; set; }

        public ICollection<StudentGroups> StudentGroups { get; set; }
    }
}
