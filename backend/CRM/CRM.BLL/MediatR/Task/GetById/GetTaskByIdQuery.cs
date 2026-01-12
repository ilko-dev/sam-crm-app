using Ardalis.Result;
using CRM.BLL.DTO.Task;
using MediatR;

namespace CRM.BLL.MediatR.Task.GetById
{
    public record GetTaskByIdQuery(int Id) : IRequest<Result<TaskDTO>>
    {
    }
}
