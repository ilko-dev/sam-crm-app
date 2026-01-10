using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.User;
using CRM.DAL.Context;
using CRM.DAL.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.GetById
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, Result<UserDTO?>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDTO>> Handle(
            GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(request.Email);

                if (user is null)
                    return Result.NotFound("User not found");

                return Result.Success(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
