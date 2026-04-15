using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events
{
    public sealed record UserDomainEvent(User User) : INotification;
}
