using Ardalis.Result;
using MediatR;

namespace CRM.BLL.MediatR.Deal.Delete
{
    public record DeleteDealCommand(int Id)
        : IRequest<Result>;
}