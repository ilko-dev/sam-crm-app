using Ardalis.Result;
using CRM.BLL.DTO.User;
using MediatR; 

namespace CRM.BLL.MediatR.Client.Create
{
    public record CreateUserCommand(CreateUserDTO Dto)
        : IRequest<Result<UserDTO>>;
}
