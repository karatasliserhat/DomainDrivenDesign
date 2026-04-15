using DomainDrivenDesign.Domain.Entities;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Categories
{
    public sealed class Category : Entity
    {
        public Name Name { get; private set; }

        private Category(Guid id):base(id) 
        {
            
        }
        public Category(Guid id, Name name):base(id)
        {
            Name = name;
        }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        public ICollection<Product> Products { get; set; }
    }
}
