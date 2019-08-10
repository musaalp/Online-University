using System.Threading.Tasks;

namespace OnlineUniversity.Domain
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}
