using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp2.Models
{
    public class AccountHolder
    {
        private readonly AccountModel _acc;

        public string ID => _acc.ID;

        public bool HasAdminPrivileges => _acc.HasAdminPrivileges;

        public AccountHolder(AccountModel acc)
        {
            _acc = acc;
        }
    }
}
