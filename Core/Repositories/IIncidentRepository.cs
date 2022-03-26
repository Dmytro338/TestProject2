using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IIncidentRepository : IGeneralRepository<Incident>
    {
        Task DeleteByNameAsync(string name);
        Task<Incident> GetByNameAsync(string name);
        Task<IEnumerable<Incident>> GetAllWithAccountAsync();
    }
}
