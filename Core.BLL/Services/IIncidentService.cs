using BLL.Models;
using Core.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IIncidentService
    {
        Task<string> AddAsync(IncidentModel model);
        Task DeleteByNameAsync(string name);
        Task<IEnumerable<IncidentModel>> GetAll();
        Task<IncidentModel> GetByNameAsync(string name);
        Task<string> ExampleRequestAsync(IncidentViewModel model);
    }
}
