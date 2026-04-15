using DomainDrivenDesign.Application.Features.Order.Create;
using DomainDrivenDesign.Application.Features.Order.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.WebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand createOrderCommand)
        {
            await mediator.Send(createOrderCommand);

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await mediator.Send(new GetAllOrderQuery());
            return Ok(orders);
        }
    }
}
