using DomainDrivenDesign.Application.Features.User.Dtos;
using DomainDrivenDesign.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Application.Features.User.GetAll
{
    public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync(cancellationToken);
            return users.Select(u => new UserDto(u.Id, u.Name.Value, u.Email.Value, u.Password.Value, u.Address.Country, u.Address.City, u.Address.Street, u.Address.FullAddress, u.Address.PostalCode

            )).ToList();
        }
    }

}
