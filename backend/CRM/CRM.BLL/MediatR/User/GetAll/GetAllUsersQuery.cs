using Ardalis.Result;
using CRM.BLL.DTO.User;
using MediatR;

namespace CRM.BLL.MediatR.User.GetAll
{
    public record GetAllUsersQuery()
    : IRequest<Result<IEnumerable<UserDTO>>>;
}
