using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGeneralRepository<TEntity> where TEntity : class
    {      
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
