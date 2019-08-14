using MediatR;
using OnlineUniversity.Application.Exceptions;
using OnlineUniversity.Domain;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Students;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Courses.Commands.SignUpCourse
{
    public class SignUpToCourseCommandHandler : IRequestHandler<SignUpToCourseCommand, SignUpToCourseResponseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public SignUpToCourseCommandHandler(
            ICourseRepository courseRepository,
            IStudentRepository studentRepository,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<SignUpToCourseResponseDto> Handle(SignUpToCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);
            var student = await _studentRepository.GetByEmailAsync(request.StudentEmail);

            if (course == null)
            {
                throw new EntityNotFoundException(nameof(course));
            }

            if (student == null)
            {
                throw new EntityNotFoundException(nameof(student));
            }

            course.SignUpStudent(student);

            await _domainEventsDispatcher.DispatchEventsAsync();

            return new SignUpToCourseResponseDto
            {
                Message = "Sign up request have been taken. You will be notified when the action is completed"
            };
        }
    }
}
