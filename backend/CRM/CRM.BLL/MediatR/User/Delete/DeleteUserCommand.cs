using Ardalis.Result;
using MediatR;

namespace CRM.BLL.MediatR.User.Delete
{
    public record DeleteUserCommand(int Id)
    : IRequest<Result>;
}
