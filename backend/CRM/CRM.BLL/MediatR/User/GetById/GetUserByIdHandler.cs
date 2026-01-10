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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserDTO?>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDTO>> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);

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
