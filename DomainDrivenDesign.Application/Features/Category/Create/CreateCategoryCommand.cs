using DomainDrivenDesign.Application.Features.Category.Dto;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Category.Create
{
    public record CreateCategoryCommand(CreateCategoryDto CreateCategoryDto):IRequest;
}
