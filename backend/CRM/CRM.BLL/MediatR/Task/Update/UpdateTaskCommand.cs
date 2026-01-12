using Ardalis.Result;
using CRM.BLL.DTO.Task;
using MediatR; 

namespace CRM.BLL.MediatR.Client.Update
{
    public record UpdateTaskCommand(int Id, CreateUpdateTaskDTO Dto)
        : IRequest<Result>;
}
