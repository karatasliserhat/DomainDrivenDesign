using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal class ProductRepository(AppDbContext appDbContext) : IProductRepository
    {
        public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
        {
            var product = new Product(Guid.NewGuid(), new(name), quantity, new Money(amount, Currency.FromCode(currency)), categoryId);

            await appDbContext.Products.AddAsync(product, cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await appDbContext.Products.ToListAsync(cancellationToken);
        }
    }
}
