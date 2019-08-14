using MediatR;
using System;

namespace OnlineUniversity.Application.Courses.Queries
{
    public class GetCourseQuery : IRequest<CourseDto>
    {
        public Guid Id { get; set; }
    }
}
