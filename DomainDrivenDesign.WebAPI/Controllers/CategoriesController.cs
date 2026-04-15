using DomainDrivenDesign.Application.Features.Category.Create;
using DomainDrivenDesign.Application.Features.Category.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.WebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand)
        {
            await mediator.Send(createCategoryCommand);

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await mediator.Send(new GetAllCategoryQuery());
            return Ok(categories);
        }
    }
}
