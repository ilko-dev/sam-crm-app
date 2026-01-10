using CRM.BLL.DTO.Client;
using CRM.BLL.MediatR.Client.Create;
using CRM.BLL.MediatR.Client.Delete;
using CRM.BLL.MediatR.Client.GetAll;
using CRM.BLL.MediatR.Client.GetById;
using CRM.BLL.MediatR.Client.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    public class ClientsController : BaseAPIController
    {
        public ClientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAll()
        {
            return HandleResult(await _mediator.Send(new GetAllClientsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO?>> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetClientByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> Create(CreateUpdateClientDTO dto)
        {
            var result = await _mediator.Send(new CreateClientCommand(dto));

            if (result.IsSuccess)
                return CreatedAtAction(nameof(Get), new { id = result.Value!.Id }, result.Value);

            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateClientDTO dto)
        {
            return HandleResult(await _mediator.Send(new UpdateClientCommand(id, dto)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteClientCommand(id)));
        }
    }
}
