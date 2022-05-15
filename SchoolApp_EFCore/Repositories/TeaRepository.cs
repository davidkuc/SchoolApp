using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class TeaRepository : SqlRepository<Teacher>
    {
        public TeaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Teacher> GetAll()
        {
            return _dbSet.Include(x => x.Groups).ToList();
        }
    }
}
