using Microsoft.EntityFrameworkCore;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Entities;

namespace OnlineUniversity.Infrastructure.Persistence.Context
{
    public class MockOnlineUniversityContext : DbContext
    {
        public MockOnlineUniversityContext(DbContextOptions<MockOnlineUniversityContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}
