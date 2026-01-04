using CRM.BLL.DTO.Company;
using CRM.BLL.MediatR.Company.Create;
using CRM.BLL.MediatR.Company.Delete;
using CRM.BLL.MediatR.Company.GetAll;
using CRM.BLL.MediatR.Company.GetById;
using CRM.BLL.MediatR.Company.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.Company
{
    [Route("crm/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllCompaniesQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCompanyByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateCompanyDTO dto)
        {
            var result = await _mediator.Send(new CreateCompanyCommand(dto));
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateCompanyDTO dto)
        {
            var ok = await _mediator.Send(new UpdateCompanyCommand(id, dto));
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _mediator.Send(new DeleteCompanyCommand(id));
            return ok ? NoContent() : NotFound();
        }
    }
}
