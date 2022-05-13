using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class AccRepository : SqlRepository<Account>
    {
        public AccRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Account? FindAccount(string username, string password)
        {
            return _dbSet.SingleOrDefault(x => x.UserName == username && x.Password == password, null);
        }
    }
}
