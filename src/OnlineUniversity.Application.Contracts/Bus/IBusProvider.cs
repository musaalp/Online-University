using OnlineUniversity.Domain;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Contracts.Bus
{
    public interface IBusProvider
    {
        Task PublishAsync<TMessage>(TMessage msg) where TMessage : IDomainEvent;
        Task SubscribeAsync();
    }
}
