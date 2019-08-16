using MediatR;
using OnlineUniversity.Application.Contracts.Bus;
using OnlineUniversity.Domain;
using OnlineUniversity.Domain.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineUniversity.Infrastructure.RabbitMQ
{
    public class MockRabbitMQBusProvider : IBusProvider
    {
        public Queue<object> _mockQueue = new Queue<object>();

        private readonly IMediator _mediator;

        public const string QueueName = "";
        public const string ExchangeName = "";
        public const string RoutingKey = "";

        public MockRabbitMQBusProvider(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync<TMessage>(TMessage msg) where TMessage : IDomainEvent
        {
            await Task.Run(() =>
            {
                _mockQueue.Enqueue(msg);
            });
        }

        public async Task SubscribeAsync()
        {
            var studentSignedUpEvent = _mockQueue.Dequeue() as StudentSignedUpEvent;

            var studentSignUpProcessedEvent = new StudentSignUpProcessedEvent
            (
                studentSignedUpEvent.CourseId,
                studentSignedUpEvent.Email
            );

            await _mediator.Publish(studentSignUpProcessedEvent);
        }

    }
}
