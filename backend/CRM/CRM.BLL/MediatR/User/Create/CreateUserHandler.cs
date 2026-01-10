using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.Company;
using CRM.BLL.DTO.User;
using CRM.DAL.Context;
using CRM.DAL.Repositories.User;
using CRM.Domain.Entities.User;
using MediatR;
using Entities = CRM.Domain.Entities;
using BCrypt.Net;

namespace CRM.BLL.MediatR.Client.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByEmailAsync(request.Dto.Email, cancellationToken) != null)
                throw new Exception("Email already exists");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Dto.Password);

            var user = new User(request.Dto.Email, passwordHash, request.Dto.Role);
            var profile = new UserProfile(user.Id, request.Dto.FirstName, request.Dto.LastName, request.Dto.Phone);

            user.AttachProfile(profile);

            await _userRepository.AddAsync(user);

            var dto = _mapper.Map<UserDTO>(user);
            return Result.Success(dto);
        }
    }
}
