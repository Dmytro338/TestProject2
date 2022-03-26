using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly MyDBContext myDBContext;

        public ContactRepository(MyDBContext context) 
        {
            myDBContext = context;
        }

        public async Task<Contact> AddAsync(Contact entity)
        {
            return (await myDBContext.Set<Contact>().AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await myDBContext.Contacts.FindAsync(id);
            myDBContext.Contacts.Remove(entity);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await myDBContext.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<Contact>> FindAllWithDetailsAsync()
        {
            return await myDBContext.Set<Contact>().Include(c => c.Accounts).ThenInclude(c => c.Incidents).ToListAsync();
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await myDBContext.Contacts.FindAsync(id);
        }

        public async Task<string> GetEmailAsync(int id)
        {
           var entity =  await myDBContext.Contacts.FindAsync(id);

            if (entity == null)
                return null;

           return entity.Email;
        }

    }
}
