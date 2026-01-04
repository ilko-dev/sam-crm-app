using AutoMapper;
using CRM.BLL.DTO.Company;
using Entities = CRM.Domain.Entities;

namespace CRM.BLL.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Entities.Company, CompanyDTO>().ReverseMap();
            CreateMap<CreateUpdateCompanyDTO, Entities.Company>().ReverseMap();
        }
        
    }
}
