using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
    {
        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            var category = new Category(Guid.NewGuid(), new(name));

            await appDbContext.Categories.AddAsync(category, cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await appDbContext.Categories.ToListAsync(cancellationToken);
        }
    }
}
