using MediatR;
using System;

namespace OnlineUniversity.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
