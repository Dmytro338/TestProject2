using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        protected readonly MyDBContext myDBContext;

        public IncidentRepository(MyDBContext context)
        {
            myDBContext = context;
        }

        public async Task<Incident> AddAsync(Incident entity)
        {
            return (await myDBContext.Set<Incident>().AddAsync(entity)).Entity;
        }

        public async Task DeleteByNameAsync(string name)
        {
            var deletedIncident = await myDBContext.Incidents
                .Where(i => i.Name == name)
                .FirstOrDefaultAsync();
            myDBContext.Remove(deletedIncident);
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await myDBContext.Incidents.ToListAsync();
        }

        public async Task<IEnumerable<Incident>> GetAllWithAccountAsync()
        {
            return await myDBContext.Incidents
                           .Include(a => a.Account)
                           .ToListAsync();
        }

        public async Task<Incident> GetByNameAsync(string name)
        {
            return await myDBContext.Incidents
                .Where(i => i.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
