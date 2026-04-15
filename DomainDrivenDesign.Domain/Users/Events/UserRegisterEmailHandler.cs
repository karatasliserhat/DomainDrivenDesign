using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events
{
    public class UserRegisterEmailHandler : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
