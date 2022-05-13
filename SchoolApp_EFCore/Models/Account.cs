using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Account : IEntity
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Owner { get; set; }

        public bool HasAdminPrivileges { get; set; }
    }
}
