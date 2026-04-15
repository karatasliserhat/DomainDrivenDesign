using DomainDrivenDesign.Application.Features.Product.Dto;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Product.Create
{
    public record CreateProductCommand(CreateProductDto CreateProductDto):IRequest;
    
}
