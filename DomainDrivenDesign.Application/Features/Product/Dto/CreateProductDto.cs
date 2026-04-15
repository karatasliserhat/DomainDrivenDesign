namespace DomainDrivenDesign.Application.Features.Product.Dto
{
    public record CreateProductDto(string name, int quantity, decimal amount, string currency, Guid categoryId);
}
