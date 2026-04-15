using DomainDrivenDesign.Application.Features.Category.Dto;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Category.GetAll
{
    public record GetAllCategoryQuery:IRequest<List<CategoryDto>>;

}
