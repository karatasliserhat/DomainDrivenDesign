namespace DomainDrivenDesign.Application.Features.Product.Dto
{
    public record ProductDto(Guid id,string name, int quantity, decimal amount, string currency, Guid categoryId);
}
