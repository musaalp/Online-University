using System;

namespace OnlineUniversity.Domain.Students
{
    public class StudentSignedUpEvent : DomainEventBase
    {
        public StudentSignedUpEvent(Guid courseId, string email)
        {
            CourseId = courseId;
            Email = email;
        }

        public Guid CourseId { get; set; }
        public string Email { get; set; }
    }
}
