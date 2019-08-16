using OnlineUniversity.Domain.Entities;
using OnlineUniversity.Domain.Students;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineUniversity.Infrastructure.Persistence.Courses
{
    public class StudentRepository : IStudentRepository
    {
        private HashSet<Student> _mockContext = new HashSet<Student>();

        public async Task<Student> GetByEmailAsync(string email)
        {
            return await Task.FromResult(_mockContext.FirstOrDefault(s => s.Email == email));
        }
    }
}
