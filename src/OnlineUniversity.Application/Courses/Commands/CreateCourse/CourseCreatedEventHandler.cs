using MediatR;
using OnlineUniversity.Domain.Courses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Courses.Commands.CreateCourse
{
    public class CourseCreatedEventHandler : INotificationHandler<CourseCreatedEvent>
    {
        public CourseCreatedEventHandler()
        {
        }

        public Task Handle(CourseCreatedEvent notification, CancellationToken cancellationToken)
        {
            // send a message if required

            throw new NotImplementedException();
        }
    }
}
