using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAccountService : IService<AccountModel>
    {
        Task<IEnumerable<AccountModel>> GetAllWithContactAsync();
    }
}
