using DomainDrivenDesign.Application.Features.Product.Create;
using DomainDrivenDesign.Application.Features.Product.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.WebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand createProductCommand)
        {
            await mediator.Send(createProductCommand);

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }
    }
}
