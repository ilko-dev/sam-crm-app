using Ardalis.Result;
using CRM.BLL.DTO.User;
using MediatR;

namespace CRM.BLL.MediatR.User.GetById
{
    public record GetUserByEmailQuery(string Email)
     : IRequest<Result<UserDTO?>>;
}
