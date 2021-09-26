using BookStore.Core.Constans;
using BookStore.Core.Data.Abstract;
using BookStore.Core.Entities.Abstract;
using BookStore.Core.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
            where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public Result<TEntity> AddRelated(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Add(entity);
                    int rowNum = context.SaveChanges();
                    if (rowNum > 0)
                    {
                        return new Result<TEntity>(true, string.Format("{0} {1}", rowNum, Messages.Inserted), entity);
                    }
                    return new Result<TEntity>(false, string.Format("{0} {1}", rowNum, Messages.NotInserted), entity);
                }
            }
            catch (Exception ex)
            {
                return new Result<TEntity>(false, string.Format("{0} {1} {2}", Messages.InsertedFail, ex.Message, ex.InnerException), null);
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public Result<TEntity> AddResult(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Add(entity);
                    int rowNum = context.SaveChanges();
                    if (rowNum > 0)
                    {
                        return new Result<TEntity>(true, string.Format("{0} {1}", rowNum, Messages.Inserted), entity);
                    }
                    return new Result<TEntity>(false, string.Format("{0} {1}", rowNum, Messages.NotInserted), entity);
                }
            }
            catch (Exception exception)
            {
                return new Result<TEntity>(false, string.Format("{0} {1} {2}", Messages.InsertedFail, exception.Message, exception.InnerException), null);
            }
        }

        public async Task BulkAddAsync(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.Entry(entities.FirstOrDefault()).Context.AddRange(entities.ToList<object>());
                await context.SaveChangesAsync();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public Result<List<TEntity>> GetListResult(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    var result = filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                    if (result.Any())
                    {
                        return new Result<List<TEntity>>(true, Messages.Successful, result.ToList());
                    }
                    else
                    {
                        return new Result<List<TEntity>>(false, Messages.Unsuccessful, null);
                    }
                }
            }
            catch (Exception exception)
            {
                return new Result<List<TEntity>>(false, string.Format("{0} {1}", Messages.Unsuccessful, exception.Message), null);
            }
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public Result<TEntity> GetResult(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    return new Result<TEntity>(true, Messages.Successful, context.Set<TEntity>().SingleOrDefault(filter));
                }
            }
            catch (Exception exception)
            {
                return new Result<TEntity>(false, string.Format("{0} {1}", Messages.DatabaseQueryError, exception.Message), null);
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public Result<TEntity> UpdateResult(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    int rowNum = context.SaveChanges();
                    if (rowNum > 0)
                    {
                        return new Result<TEntity>(true, string.Format("{0} {1}", rowNum, Messages.Modified), entity);
                    }
                    return new Result<TEntity>(false, string.Format("{0} {1}", rowNum, Messages.NotModified), entity);
                }
            }
            catch (Exception ex)
            {
                return new Result<TEntity>(false, string.Format("{0} {1} {2}", Messages.ModifiedFail, ex.Message, ex.InnerException), null);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Remove(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().RemoveRange(GetList(filter));
                await context.SaveChangesAsync();
            }
        }
    }
}