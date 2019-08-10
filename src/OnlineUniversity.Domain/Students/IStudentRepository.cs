using OnlineUniversity.Domain.Entities;
using System.Threading.Tasks;

namespace OnlineUniversity.Domain.Students
{
    public interface IStudentRepository
    {
        Task<Student> GetByEmailAsync(string email);
    }
}
