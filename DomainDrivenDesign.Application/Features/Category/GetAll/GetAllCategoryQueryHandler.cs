using DomainDrivenDesign.Application.Features.Category.Dto;
using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Category.GetAll
{
    internal class GetAllCategoryQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAllAsync(cancellationToken)
                .ContinueWith(task => task.Result.Select(category => new CategoryDto(category.Id, category.Name.Value)).ToList(), cancellationToken);
        }
    }
}
