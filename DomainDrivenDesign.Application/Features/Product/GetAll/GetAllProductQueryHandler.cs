using DomainDrivenDesign.Application.Features.Product.Dto;
using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Product.GetAll
{
    internal class GetAllProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync(cancellationToken);

            return products.Select(x => new ProductDto(x.Id, x.Name.Value, x.Quantity, x.Price.Amaount, x.Price.currency.Code, x.CategoryId)).ToList();
        }
    }
}
