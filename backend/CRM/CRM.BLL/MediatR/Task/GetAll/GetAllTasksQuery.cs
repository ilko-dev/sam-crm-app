using Ardalis.Result;
using CRM.BLL.DTO.Task;
using MediatR;

namespace CRM.BLL.MediatR.Task.GetAll
{
    public record GetAllTasksQuery : IRequest<Result<IEnumerable<TaskDTO>>>
    {
    }
}
