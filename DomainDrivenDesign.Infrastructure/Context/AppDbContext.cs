using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Entities;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Context
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>
                (u => u.Property(name => name.Name).HasConversion(x => x.Value, x => new(x)));

            modelBuilder.Entity<User>
                (u => u.Property(password => password.Password).HasConversion(x => x.Value, x => new(x)));

            modelBuilder.Entity<User>
                (u => u.Property(email => email.Email).HasConversion(x => x.Value, x => new(x)));

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address);

            modelBuilder.Entity<Category>
                (c => c.Property(name => name.Name).HasConversion(x => x.Value, x => new(x)));


            modelBuilder.Entity<Product>
                (p => p.Property(name => name.Name).HasConversion(x => x.Value, x => new(x)));

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder.Property(p => p.currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder.Property(p => p.Amaount).HasColumnType("money");
                });

            modelBuilder.Entity<OrderLine>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder.Property(p => p.currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder.Property(p => p.Amaount).HasColumnType("money");
                });
        }
    }
}
