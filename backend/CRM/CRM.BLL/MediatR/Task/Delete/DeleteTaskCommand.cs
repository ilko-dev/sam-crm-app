using Ardalis.Result;
using CRM.BLL.DTO.Task;
using MediatR; 

namespace CRM.BLL.MediatR.Client.Delete
{
    public record DeleteTaskCommand(int Id)
        : IRequest<Result>;
}
