using MediatR;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Students;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Courses.Commands.SignUpCourse
{
    public class StudentSignUpProcessedEventHandler : INotificationHandler<StudentSignUpProcessedEvent>
    {
        private readonly ICourseSignUpPolicy _policy;

        public StudentSignUpProcessedEventHandler(ICourseSignUpPolicy policy)
        {
            _policy = policy;
        }

        public async Task Handle(StudentSignUpProcessedEvent notification, CancellationToken cancellationToken)
        {
            var hasEnoughSlot = await _policy.CheckCapacity(notification.CourseId);

            if (hasEnoughSlot)
            {
                // send success message to student
            }
            else
            {
                // send error message to student
            }
        }
    }
}
