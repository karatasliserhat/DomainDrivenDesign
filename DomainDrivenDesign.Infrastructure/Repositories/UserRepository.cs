using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        public async Task<User> CreateAsync(string name, string email, string password, string Country, string City, string Street, string FullAddress, string PostalCode, CancellationToken cancellationToken = default)
        {
            var user = User.CreateUser(new(name), new(email), new(password), Country, City, Street, FullAddress, PostalCode);
            await appDbContext.Users.AddAsync(user, cancellationToken);

            await appDbContext.SaveChangesAsync(cancellationToken);

            return user;
        }

        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return appDbContext.Users.ToListAsync(cancellationToken);
        }
    }
}
