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
            return GetAll().SingleOrDefault(x => x.Username == username && x.Password == password, null);
        }
    }
}
