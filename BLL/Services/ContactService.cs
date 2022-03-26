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
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<int> AddAsync(ContactModel model)
        {
            if (model == null || String.IsNullOrEmpty(model.Email))
            {
                throw new Exception();
            }

            var contact = await unitOfWork.Contacts.AddAsync(mapper.Map<Contact>(model));
            await unitOfWork.CommitAsync();
            return contact.Id;
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.Contacts.DeleteAsync(modelId);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ContactModel>> GetAll()
        {
            var source = await unitOfWork.Contacts.GetAllAsync();
            return mapper.Map<IEnumerable<ContactModel>>(source);
        }

        public async Task<ContactModel> GetAsync(int id)
        {
            var source = await unitOfWork.Contacts.GetAsync(id);
            return mapper.Map<ContactModel>(source);
        }
    }
}
