using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IContactRepository Contacts { get; }
        IIncidentRepository Incidents { get; }
     
        Task<int> CommitAsync();
    }
}
