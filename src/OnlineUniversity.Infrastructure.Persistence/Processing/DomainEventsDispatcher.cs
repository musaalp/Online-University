using MediatR;
using OnlineUniversity.Domain;
using OnlineUniversity.Infrastructure.Persistence.Context;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineUniversity.Infrastructure.Persistence.Processing
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly MockOnlineUniversityContext _dbContext;

        public DomainEventsDispatcher(IMediator mediator, MockOnlineUniversityContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task DispatchEventsAsync()
        {
            var domainEntities = _dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await _mediator.Publish(domainEvent);
                });

            domainEntities.ForEach(d => d.Entity.ClearDomainEvents());

            await Task.WhenAll(tasks);
        }
    }
}
