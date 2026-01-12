using CRM.BLL.DTO.Task;
using CRM.BLL.MediatR.Client.Delete;
using CRM.BLL.MediatR.Client.Update;
using CRM.BLL.MediatR.Task.Create;
using CRM.BLL.MediatR.Task.GetAll;
using CRM.BLL.MediatR.Task.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    public class TasksController : BaseAPIController
    {
        public TasksController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAll()
        {
            return HandleResult(await _mediator.Send(new GetAllTasksQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO?>> GetById(int id)
        {
            return HandleResult(await _mediator.Send(new GetTaskByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<TaskDTO>> Create(CreateUpdateTaskDTO dto)
        {
            var result = await _mediator.Send(new CreateTaskCommand(dto));

            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value);

            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateTaskDTO dto)
        {
            return HandleResult(await _mediator.Send(new UpdateTaskCommand(id, dto)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteTaskCommand(id)));
        }
    }
}
