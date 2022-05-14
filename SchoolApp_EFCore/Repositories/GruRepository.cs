using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class GruRepository : SqlRepository<Group>
    {
        public GruRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
