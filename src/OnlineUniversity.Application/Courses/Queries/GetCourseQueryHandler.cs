using MediatR;
using OnlineUniversity.Application.Exceptions;
using OnlineUniversity.Domain.Courses;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Courses.Queries
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null)
            {
                throw new EntityNotFoundException($"Entity not found with given id: {request.Id}");
            }

            return new CourseDto
            {
                Id = course.Id.ToString(),
                Capacity = course.Capacity,
                NumberOfStudents = course.Students.Count
            };
        }
    }
}
