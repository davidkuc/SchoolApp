using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class GruStudRepository : SqlRepository<GroupStudent>
    {
        public GruStudRepository(DbContext dbContext) : base(dbContext)
        {
        }


        /// <summary>
        /// Wyszukuje encję o podanym kluczu (ID studenta oraz ID grupy)
        /// </summary>
        /// <param name="studID">ID studenta</param>
        /// <param name="groupID">ID grupy</param>
        /// <returns>Zwraca encję typu GroupStudent, jeżeli nie istnieje zwraca null </returns>
        public GroupStudent? GetByKeys(int studID, int groupID)
        {
            return GetAll().SingleOrDefault(x => x.StudentId == studID && x.GroupId == groupID, null);
        }
    }
}
