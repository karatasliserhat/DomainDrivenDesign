using DomainDrivenDesign.Application.Features.User.Dtos;
using MediatR;

namespace DomainDrivenDesign.Application.Features.User.Create
{
    public record CreateUserCommand(CreateUserDto CreateUserDto) : IRequest;
}
