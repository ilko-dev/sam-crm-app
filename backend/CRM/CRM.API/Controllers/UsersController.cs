using CRM.BLL.DTO.Company;
using CRM.BLL.DTO.User;
using CRM.BLL.MediatR.Client.Create;
using CRM.BLL.MediatR.Client.Delete;
using CRM.BLL.MediatR.Client.GetAll;
using CRM.BLL.MediatR.Client.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    public class UsersController : BaseAPIController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return HandleResult(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO?>> GetById(int id)
        {
            return HandleResult(await _mediator.Send(new GetUserByIdQuery(id)));
        }

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<UserDTO?>> GetByEmail(string email)
        {
            return HandleResult(await _mediator.Send(new GetUserByEmailQuery(email)));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(CreateUserDTO dto)
        {
            var result = await _mediator.Send(new CreateUserCommand(dto));

            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value);

            return HandleResult(result);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, CreateUpdateCompanyDTO dto)
        //{
        //    return HandleResult(await _mediator.Send(new UpdateCompanyCommand(id, dto)));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteUserCommand(id)));
        }
    }
}
