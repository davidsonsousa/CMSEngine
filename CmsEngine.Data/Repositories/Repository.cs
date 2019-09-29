using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsEngine.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CmsEngine.Data.Repositories
{
    public class Repository<TEntity> : IReadRepository<TEntity>,
                                       IDataModificationRepository<TEntity>,
                                       IDataModificationRangeRepository<TEntity>
                                       where TEntity : BaseEntity
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException("Repository - Context");
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await GetValidRecords().ToListAsync();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, int count = 0)
        {
            var recods = GetValidRecords();

            if (filter != null)
            {
                recods = recods.Where(filter);
            }

            if (count > 0)
            {
                recods = recods.Take(count);
            }

            return recods;
        }

        public async Task<IEnumerable<TEntity>> GetReadOnly(Expression<Func<TEntity, bool>> filter = null)
        {
            var records = GetValidRecords();

            if (filter != null)
            {
                records = records.Where(filter);
            }

            return await records.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Get(q => q.Id == id).SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await Get(q => q.VanityId == id).SingleOrDefaultAsync();
        }

        public async Task Insert(TEntity entity)
        {
            if (entity != null)
            {
                await dbContext.Set<TEntity>().AddAsync(entity);
            }
        }

        public async Task InsertRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                await dbContext.Set<TEntity>().AddRangeAsync(entities);
            }
        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                Attach(entity);
                dbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                dbContext.UpdateRange(entities);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                // We never delete anything
                entity.IsDeleted = true;
                Update(entity);
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                for (int i = 0; i < entities.Count(); i++)
                {
                    ((List<TEntity>)entities)[i].IsDeleted = true;
                }

                // We never delete anything
                UpdateRange(entities);
            }
        }

        private void Attach(TEntity entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbContext.Set<TEntity>().Attach(entity);
            }
        }

        private IQueryable<TEntity> GetValidRecords()
        {
            return dbContext.Set<TEntity>().Where(q => q.IsDeleted == false);
        }
    }
}