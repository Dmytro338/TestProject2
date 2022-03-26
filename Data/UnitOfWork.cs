using Core;
using Core.Repositories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyDBContext _context;
        private ContactRepository contactRepository;
        private AccountRepository accountRepository;
        private IncidentRepository incidentRepository;

        public UnitOfWork(MyDBContext context)
        {
            _context = context;
        }

        public IIncidentRepository Incidents => incidentRepository = incidentRepository ?? new IncidentRepository(_context);

        public IAccountRepository Accounts => accountRepository = accountRepository ?? new AccountRepository(_context);

        public IContactRepository Contacts => contactRepository = contactRepository ?? new ContactRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
