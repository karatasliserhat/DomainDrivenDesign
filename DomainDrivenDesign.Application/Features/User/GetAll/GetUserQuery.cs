using DomainDrivenDesign.Application.Features.User.Dtos;
using MediatR;

namespace DomainDrivenDesign.Application.Features.User.GetAll
{
    public record GetUserQuery:IRequest<List<UserDto>>;

}
