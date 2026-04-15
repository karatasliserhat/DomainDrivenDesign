using DomainDrivenDesign.Domain.Entities;
using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Product.Create
{
    internal class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.CreateAsync(
                request.CreateProductDto.name, 
                request.CreateProductDto.quantity, 
                request.CreateProductDto.amount, 
                request.CreateProductDto.currency, 
                request.CreateProductDto.categoryId, 
                cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
