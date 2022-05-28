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

        /// <summary>
        /// Wyszukuje encję o podanym kluczu (ID nauczyciela oraz ID grupy)
        /// </summary>
        /// <param name="teaID">ID nauczyciela</param>
        /// <param name="groupID">ID grupy</param>
        /// <returns>Zwraca encję typu GroupTeacher, jeżeli nie istnieje zwraca null </returns>
        public GroupTeacher? GetByKeys(int teaID, int groupID)
        {
            return GetAll().SingleOrDefault(x => x.TeacherId == teaID && x.GroupId == groupID, null);
        }
    }
}
