using AutoMapper;
using BLL.Models;
using Core;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<int> AddAsync(AccountModel model)
        {
            if (model is null)
            {
                throw new ArgumentException();
            }
            var account = await unitOfWork.Accounts.AddAsync(mapper.Map<Account>(model));
            if (account == null)
            {
                throw new ArgumentException();
            }
            await unitOfWork.CommitAsync();
            return account.Id;
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.Accounts.DeleteAsync(modelId);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AccountModel>> GetAll()
        {
            var source = await unitOfWork.Accounts.GetAllAsync();
            return mapper.Map<IEnumerable<AccountModel>>(source);
        }

        public async Task<IEnumerable<AccountModel>> GetAllWithContactAsync()
        {
            var source = await unitOfWork.Accounts.GetAllWithContactAsync(); 
            return mapper.Map<IEnumerable<AccountModel>>(source);
        }

        public async Task<AccountModel> GetAsync(int id)
        {
            var source = await unitOfWork.Accounts.GetAsync(id);
            return mapper.Map<AccountModel>(source);
        }
    }
}
