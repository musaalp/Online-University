using System;

namespace OnlineUniversity.Domain.Students
{
    public class StudentSignUpProcessedEvent : DomainEventBase
    {
        public StudentSignUpProcessedEvent(Guid courseId, string email)
        {
            CourseId = courseId;
            Email = email;
        }

        public Guid CourseId { get; set; }
        public string Email { get; set; }
    }
}
