using System;
using System.Threading.Tasks;

namespace OnlineUniversity.Domain.Courses
{
    public interface ICourseSignUpPolicy
    {
        Task<bool> CheckCapacity(Guid courseId);
    }
}
