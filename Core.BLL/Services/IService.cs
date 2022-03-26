using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity model);

        Task DeleteAsync(int modelId);
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetAsync(int id);

     
    }
}
