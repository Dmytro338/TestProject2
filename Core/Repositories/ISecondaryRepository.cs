using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISecondaryRepository<TEntity> where TEntity : class
    {

        Task DeleteAsync(int id);
        Task<TEntity> GetAsync(int id);
    }
}
