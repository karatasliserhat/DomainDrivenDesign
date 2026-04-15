using DomainDrivenDesign.Application.Features.Product.Dto;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Product.GetAll
{
    public record GetAllProductQuery:IRequest<List<ProductDto>>;
}
