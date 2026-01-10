using Ardalis.Result;
using CRM.BLL.DTO.User;
using MediatR;

namespace CRM.BLL.MediatR.Client.GetById
{
    public record GetUserByIdQuery(int Id)
     : IRequest<Result<UserDTO?>>;
}
