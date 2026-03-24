using AutoMapper;
using CRM.BLL.DTO.Deal;
using CRM.Domain.Entities;

namespace CRM.BLL.Mapping
{
    public class DealProfile : Profile
    {
        public DealProfile()
        {
            CreateMap<Deal, DealDTO>()
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => src.Client != null
                        ? $"{src.Client.FirstName} {src.Client.LastName}"
                        : string.Empty))
                .ForMember(dest => dest.AssignedUserName,
                    opt => opt.MapFrom(src => src.AssignedUser != null && src.AssignedUser.Profile != null
                        ? $"{src.AssignedUser.Profile.FirstName} {src.AssignedUser.Profile.LastName}"
                        : null));

            CreateMap<CreateUpdateDealDTO, Deal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Client, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedUser, opt => opt.Ignore());
        }
    }
}