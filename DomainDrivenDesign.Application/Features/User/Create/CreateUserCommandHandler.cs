using DomainDrivenDesign.Domain.Entities;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.User.Create
{
    public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user=await userRepository.CreateAsync(
                request.CreateUserDto.name,
                request.CreateUserDto.email,
                request.CreateUserDto.password,
                request.CreateUserDto.Country,
                request.CreateUserDto.City,
                request.CreateUserDto.Street,
                request.CreateUserDto.FullAddress,
                request.CreateUserDto.PostalCode,
                cancellationToken);
            await unitOfWork.SaveChangeAsync();

            await mediator.Publish(new UserDomainEvent(user), cancellationToken);
        }
    }
}

