using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.User;
using CRM.DAL.Context;
using CRM.DAL.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDTO>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<UserDTO>>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var dtos = _mapper.Map<IEnumerable<UserDTO>>(users);

                return Result<IEnumerable<UserDTO>>.Success(dtos);
            }
            catch(Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
