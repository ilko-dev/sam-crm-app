using Ardalis.Result;
using CRM.BLL.DTO.User;
using MediatR;

namespace CRM.BLL.MediatR.Client.GetById
{
    public record GetUserByEmailQuery(string Email)
     : IRequest<Result<UserDTO?>>;
}
