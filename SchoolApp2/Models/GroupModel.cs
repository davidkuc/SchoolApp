using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp2.Models
{

    public class GroupModel
    {
        public string SCode { get; set; }

        public string ActivityForm { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return $"{ActivityForm}/{SCode}";
        }
    }
}
