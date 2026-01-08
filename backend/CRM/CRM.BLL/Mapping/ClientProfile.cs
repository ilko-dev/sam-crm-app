using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.Company;
using CRM.Domain.Entities;

namespace CRM.BLL.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src =>
                        $"{src.FirstName} {src.LastName}"));
            CreateMap<CreateUpdateClientDTO, Client>().ReverseMap();
        }
    }
}
