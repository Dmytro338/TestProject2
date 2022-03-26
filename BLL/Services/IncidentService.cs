using AutoMapper;
using BLL.Models;
using Core;
using Core.BLL.ViewModels;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public IncidentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IncidentModel>> GetAll()
        {
            var source = await unitOfWork.Incidents.GetAllAsync();
            return mapper.Map<IEnumerable<IncidentModel>>(source);
        }

        public async Task<IncidentModel> GetByNameAsync(string name)
        {
            var source = await unitOfWork.Incidents.GetByNameAsync(name);
            return mapper.Map<IncidentModel>(source);
        }

        public async Task<string> ExampleRequestAsync(IncidentViewModel model)
        {
            if (model is null || String.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException();
            }

            var account = (await unitOfWork.Accounts.GetAllAsync()).FirstOrDefault(a => a.Name == model.AccountName);
            if (account == null)
            {
                throw new ArgumentException("Account's name wasn't specified");
            }

            var contact = (await unitOfWork.Contacts.FindAllWithDetailsAsync()).FirstOrDefault(a => a.Email == model.Email);
            if (contact == null)
            {
                contact = await unitOfWork.Contacts.AddAsync(mapper.Map<Contact>(new Contact()
                {
                    Email = model.Email,
                    FirstName = model.FirsName,
                    LastName = model.LastName,
                    Accounts = new List<Account>()
                }));
                await unitOfWork.CommitAsync();
            }

            if (!contact.Accounts.Contains(account))
            {
                contact!.Accounts.Add(account);
            }

            var incident = new Incident()
            {
                Account = account,
                Description = model.IncidentDescription
            };

            var result = await unitOfWork.Incidents.AddAsync(incident);
            await unitOfWork.CommitAsync();
            return result.Name;
        }

        public async Task<string> AddAsync(IncidentModel model)
        {
            var incident = await unitOfWork.Incidents.AddAsync(mapper.Map<Incident>(model));
            await unitOfWork.CommitAsync();
            return incident.Name;
        }

        public async Task DeleteByNameAsync(string name)
        {
            await unitOfWork.Incidents.DeleteByNameAsync(name);
            await unitOfWork.CommitAsync();
        }
    }
}
