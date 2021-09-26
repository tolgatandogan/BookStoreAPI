using BookStore.Core.Entities.Abstract;
using BookStore.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        Result<T> GetResult(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        Result<List<T>> GetListResult(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        Result<T> AddRelated(T entity);

        Result<T> AddResult(T entity);

        Task BulkAddAsync(IEnumerable<T> entitys);

        Task Remove(Expression<Func<T, bool>> filter = null);

        T Update(T entity);

        Result<T> UpdateResult(T entity);

        Task<T> UpdateAsync(T entity);

        void Delete(T entity);

        Task DeleteAsync(T entity);
    }
}