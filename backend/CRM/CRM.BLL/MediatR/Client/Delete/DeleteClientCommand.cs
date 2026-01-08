using Ardalis.Result;
using MediatR;

namespace CRM.BLL.MediatR.Client.Delete
{
    public record DeleteClientCommand(Guid Id)
    : IRequest<Result>;
}
