using System;
using System.Threading.Tasks;

namespace OnlineUniversity.Domain.Courses
{
    public class CoursesSignupPolicy : ICourseSignUpPolicy
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesSignupPolicy(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> CheckCapacity(Guid courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);

            return course.Students.Count < course.Capacity;
        }
    }
}
