using MediatR;
using OnlineUniversity.Domain;
using OnlineUniversity.Domain.Courses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public CreateCourseCommandHandler(ICourseRepository courseRepository, IDomainEventsDispatcher domainEventsDispatcher)
        {
            _courseRepository = courseRepository;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course(request.Name, request.Capacity, request.LecturerId);

            await _courseRepository.CreateAsync(course);

            await _domainEventsDispatcher.DispatchEventsAsync();

            return course.Id;
        }
    }
}
