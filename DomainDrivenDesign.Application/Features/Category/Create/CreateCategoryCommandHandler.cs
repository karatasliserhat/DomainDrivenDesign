using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Entities;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Category.Create
{
    internal class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand>
    {
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await categoryRepository.CreateAsync(request.CreateCategoryDto.name, cancellationToken);
            await unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
