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

        /// <summary>
        /// Wyszukuje konto z podanym username i password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Zwraca encję typu Account, jeżeli nie istnieje zwraca null</returns>
        public Account? FindAccount(string username, string password)
        {
            return GetAll().SingleOrDefault(x => x.Username == username && x.Password == password, null);
        }
    }
}
