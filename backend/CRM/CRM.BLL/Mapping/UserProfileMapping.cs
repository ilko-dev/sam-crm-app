using AutoMapper;
using CRM.BLL.DTO.User;
using CRM.BLL.MediatR.Client.Create;
using CRM.Domain.Entities.User;

namespace CRM.BLL.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Profile.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Profile.LastName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Profile.Phone));
        }
    }
}
