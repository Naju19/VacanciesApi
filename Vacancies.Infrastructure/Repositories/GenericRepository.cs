using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly VacancyDbContext context;
        public readonly DbSet<TEntity> dbSet;


        public GenericRepository(VacancyDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null, List<string>? includes = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includes!=null && includes.Count > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);

        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task RemoveAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await RemoveAsync(entityToDelete);
            await context.SaveChangesAsync();
        }


        /// <summary>
        /// should be applied shoft delete
        /// </summary>
        /// <param name="entityToDelete"></param>
        /// <returns></returns>
        public virtual async Task RemoveAsync(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();

        }


        //public async ValueTask DisposeAsync()
        //{
        //    await ValueTask.FromResult(await context.SaveChangesAsync());
        //    await ValueTask.CompletedTask;
        //}

    }
}
