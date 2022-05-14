using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);

        void Remove(T item);

        void Save();

        void Update(T item);

        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}
