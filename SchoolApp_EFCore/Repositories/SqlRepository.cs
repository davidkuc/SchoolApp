using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _dbContext;

        /// <summary>
        /// Tworzy SqlRepository przyjmując dbContext
        /// </summary>
        /// <param name="dbContext">dbContext</param>
        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        /// <summary>
        /// Dodaje encję do tabeli
        /// </summary>
        /// <param name="item">Encja</param>
        public virtual void Add(T item)
        {
            _dbSet.Add(item);
        }

        /// <summary>
        ///  Zwraca wszystkie encje z tabeli
        /// </summary>
        /// <returns>IEnumerable encji typu T</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Wyszukuje encję o podanym ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Encję o podanym ID, jeżeli nie istnieje, zwraca null</returns>
        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Zwraca encję która znajduje się na końcu tabeli
        /// </summary>
        /// <returns>Ostatnia encja w tabeli</returns>
        public T GetLast()
        {
            return _dbSet.OrderBy(p => p.ID).Last();
        }

        /// <summary>
        /// Usuwa wybraną encję z tabeli
        /// </summary>
        /// <param name="item">Encja do usunięcia z tabeli</param>
        public virtual void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        /// <summary>
        /// Zapisuje zmiany poczynione w tabeli
        /// </summary>
        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Zmienia stan encji na 'zmodyfikowany' oraz zapisuje zmiany wprowadzone do encji
        /// </summary>
        /// <param name="itemChanges">Encja z wprowadzonymi zmianami</param>
        public virtual void Update(T itemChanges)
        {
            var item = _dbSet.Attach(itemChanges);
            item.State = EntityState.Modified;
            Save();
        }
    }
}
