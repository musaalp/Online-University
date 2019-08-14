using MediatR;
using System;

namespace OnlineUniversity.Application.Courses.Commands.SignUpCourse
{
    public class SignUpToCourseCommand : IRequest<SignUpToCourseResponseDto>
    {
        public Guid CourseId { get; set; }
        public string StudentFullName { get; set; }
        public string StudentEmail { get; set; }
    }
}
