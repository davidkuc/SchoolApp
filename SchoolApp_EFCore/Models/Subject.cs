using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Subject : IEntity
    {
        public string Code { get; set; }

        public string ActivityForm { get; set; }

        public int ID { get; set; }
    }
}
