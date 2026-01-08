using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("crm/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult HandleResult(Result result) => this.ToActionResult(result);
        protected ActionResult<T> HandleResult<T>(Result<T> result) => this.ToActionResult(result);
    }
}