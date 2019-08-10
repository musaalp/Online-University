using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineUniversity.Domain.Courses
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course);

        Task<Course> GetByIdAsync(Guid id);

        Task<IQueryable<Course>> GetAllAsync();
    }
}
