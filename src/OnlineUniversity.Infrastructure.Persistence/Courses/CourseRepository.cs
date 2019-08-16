using OnlineUniversity.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineUniversity.Infrastructure.Persistence.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private HashSet<Course> _mockContext = new HashSet<Course>();

        public async Task CreateAsync(Course course)
        {
            await Task.Run(() =>
            {
                _mockContext.Add(course);
            });
        }

        public async Task<IQueryable<Course>> GetAllAsync()
        {
            return await Task.FromResult(_mockContext.AsQueryable());
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_mockContext.FirstOrDefault(c => c.Id == id));
        }
    }
}
