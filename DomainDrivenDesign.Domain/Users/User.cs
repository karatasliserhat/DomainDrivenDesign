using DomainDrivenDesign.Domain.Entities;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, Name name, Email email, Password password, Address address) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Address Address { get; private set; }

        public static User CreateUser(Name name, Email email, Password password, string Country, string City, string Street, string FullAddress, string PostalCode)
        {
            return new User(Guid.NewGuid(),
                name: name,
                email: email,
                password: password,
                address: new Address(
                    Country: Country,
                    City: City,
                    Street: Street,
                    FullAddress: FullAddress,
                    PostalCode: PostalCode)
                );
        }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        public void ChangePassword(string password)
        {
            Password = new Password(password);
        }

        public void ChangeAddress(string Country, string City, string Street, string FullAddress, string PostalCode)
        {
            Address = new Address(Country, City, Street, FullAddress, PostalCode);
        }
    }
}
