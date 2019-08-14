using OnlineUniversity.Application.Students;

namespace OnlineUniversity.Application.Courses.Commands.SignUpCourse
{
    public class SignUpToCourseRequestDto
    {
        public string CourseId { get; set; }
        public StudentDto Student { get; set; }
    }
}
