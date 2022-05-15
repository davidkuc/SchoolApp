using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class GruTeaRepository : SqlRepository<GroupTeacher>
    {
        public GruTeaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public GroupTeacher? GetByKeys(string teaID, string groupID)
        {
            return GetAll().SingleOrDefault(x => x.TeacherId == teaID && x.GroupId == groupID, null);
        }
    }
}
