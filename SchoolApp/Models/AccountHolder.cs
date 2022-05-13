using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class AccountHolder
    {
        private readonly Account _acc;

        public int ID => _acc.ID;

        public AccountHolder(Account acc)
        {
            _acc = acc;
        }
    }
}
