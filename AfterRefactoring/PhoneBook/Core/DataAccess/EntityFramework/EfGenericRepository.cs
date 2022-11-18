using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfGenericRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        { 
            using (var dbContext = new TContext())
            { 
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        } 
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var dbContext = new TContext())
            { 
                return dbContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var dbContext = new TContext())
            { 
                return filter == null ?
                    dbContext.Set<TEntity>().ToList() :
                    dbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var dbContext = new TContext())
            { 
                var updatedEntity = dbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
