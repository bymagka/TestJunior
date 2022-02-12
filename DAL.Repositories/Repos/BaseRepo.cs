using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="T">тип таблицы для репозитория</typeparam>
    public class BaseRepo<T> : IRepo<T> where T : BaseEntities.BaseEntity
    {
        private readonly MyContext _dbContext;
        private readonly DbSet<T> _table;

        public BaseRepo(MyContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            _table.Add(entity);

            return SaveChanges();
        }

        public bool Add(ICollection<T> entities)
        {
            _table.AddRange(entities);

            return SaveChanges();
        }

        public ICollection<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetOne(int id)
        {
            return _table.Find(id);
        }

        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return SaveChanges();
        }

        public bool Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;

            return SaveChanges();
        }

        /// <summary>
        /// Сохраняет изменения контекста
        /// </summary>
        /// <returns></returns>
        private bool SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
            
        }

    }
}
