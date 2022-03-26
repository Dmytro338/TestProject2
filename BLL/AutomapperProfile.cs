using AutoMapper;
using BLL.Models;
using Core.Models;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Incident, IncidentModel>()
                .ReverseMap();

            CreateMap<Account, AccountModel>()
                .ReverseMap();

            CreateMap<Contact, ContactModel>()
                .ReverseMap();

        }
    }
}
