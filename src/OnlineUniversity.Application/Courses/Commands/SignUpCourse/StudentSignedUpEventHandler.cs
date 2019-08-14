using MediatR;
using OnlineUniversity.Application.Contracts.Bus;
using OnlineUniversity.Domain.Students;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Courses.Commands.SignUpCourse
{
    public class StudentSignedUpEventHandler : INotificationHandler<StudentSignedUpEvent>
    {
        private readonly IBusProvider _busProvider;

        public StudentSignedUpEventHandler(IBusProvider busProvider)
        {
            _busProvider = busProvider;
        }

        public async Task Handle(StudentSignedUpEvent notification, CancellationToken cancellationToken)
        {
            await _busProvider.PublishAsync(notification);
        }
    }
}
