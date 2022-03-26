using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SecondaryRepository<TEntity> : ISecondaryRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public SecondaryRepository(DbContext context)
        {
            this.context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(entity);
            }
            context.Set<TEntity>().Remove(entity);
        }
        public async Task<TEntity> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
    }
}
