using Ardalis.Result;
using CRM.BLL.DTO.Task;
using MediatR; 

namespace CRM.BLL.MediatR.Task.Create
{
    public record CreateTaskCommand(CreateUpdateTaskDTO Dto)
        : IRequest<Result<TaskDTO>>;
}
