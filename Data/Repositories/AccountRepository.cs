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
    public class AccountRepository : IAccountRepository
    {
        protected readonly MyDBContext myDBContext;

        public AccountRepository(MyDBContext context) 
        {
            myDBContext = context;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await myDBContext.Accounts.FindAsync(id);
            myDBContext.Accounts.Remove(entity);
        }

         public async Task<Account> GetAsync(int id)
        {
           return await myDBContext.Accounts.FindAsync(id);
        }

        public async Task<Account> AddAsync(Account entity)
        {
            return (await myDBContext.Set<Account>().AddAsync(entity)).Entity;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await myDBContext.Accounts.ToListAsync();
        }

        public Task<IEnumerable<Account>> GetAllWithContactAsync()
        {
            throw new NotImplementedException();
        }
    }
}
