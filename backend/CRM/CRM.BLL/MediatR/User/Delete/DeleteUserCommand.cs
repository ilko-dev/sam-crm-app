using Ardalis.Result;
using MediatR;

namespace CRM.BLL.MediatR.Client.Delete
{
    public record DeleteUserCommand(int Id)
    : IRequest<Result>;
}
