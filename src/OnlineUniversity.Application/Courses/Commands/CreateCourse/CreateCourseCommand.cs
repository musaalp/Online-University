using MediatR;
using System;

namespace OnlineUniversity.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public string LecturerId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
