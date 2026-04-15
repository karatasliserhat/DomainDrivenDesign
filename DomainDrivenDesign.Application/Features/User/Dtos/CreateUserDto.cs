namespace DomainDrivenDesign.Application.Features.User.Dtos
{
    public record CreateUserDto(string name, string email, string password, string Country, string City, string Street, string FullAddress, string PostalCode);
}
