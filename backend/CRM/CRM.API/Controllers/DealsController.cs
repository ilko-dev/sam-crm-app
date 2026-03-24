using CRM.BLL.DTO.Deal;
using CRM.BLL.MediatR.Deal.Create;
using CRM.BLL.MediatR.Deal.Delete;
using CRM.BLL.MediatR.Deal.GetAll;
using CRM.BLL.MediatR.Deal.GetById;
using CRM.BLL.MediatR.Deal.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    public class DealsController : BaseAPIController
    {
        public DealsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealDTO>>> GetAll()
        {
            return HandleResult(await _mediator.Send(new GetAllDealsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealDTO?>> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetDealByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<DealDTO>> Create(CreateUpdateDealDTO dto)
        {
            var result = await _mediator.Send(new CreateDealCommand(dto));

            if (result.IsSuccess)
                return CreatedAtAction(nameof(Get), new { id = result.Value!.Id }, result.Value);

            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateDealDTO dto)
        {
            return HandleResult(await _mediator.Send(new UpdateDealCommand(id, dto)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteDealCommand(id)));
        }
    }
}