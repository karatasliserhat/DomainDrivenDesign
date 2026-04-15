using DomainDrivenDesign.Application.Features.User.Create;
using DomainDrivenDesign.Application.Features.User.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.WebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand createUserCommand)
        {
            await mediator.Send(createUserCommand);

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await mediator.Send(new GetUserQuery());
            return Ok(users);
        }
    }
}
