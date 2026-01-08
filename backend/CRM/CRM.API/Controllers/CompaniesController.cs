using Ardalis.Result.AspNetCore;
using CRM.BLL.DTO.Company;
using CRM.BLL.MediatR.Company.Create;
using CRM.BLL.MediatR.Company.Delete;
using CRM.BLL.MediatR.Company.GetAll;
using CRM.BLL.MediatR.Company.GetById;
using CRM.BLL.MediatR.Company.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    public class CompaniesController : BaseAPIController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAll()
        {
            return HandleResult(await _mediator.Send(new GetAllCompaniesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO?>> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetCompanyByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> Create(CreateUpdateCompanyDTO dto)
        {
            var result = await _mediator.Send(new CreateCompanyCommand(dto));

            if (result.IsSuccess)
                return CreatedAtAction(nameof(Get), new { id = result.Value!.Id }, result.Value);

            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateCompanyDTO dto)
        {
            return HandleResult(await _mediator.Send(new UpdateCompanyCommand(id, dto)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteCompanyCommand(id)));
        }
    }
}
