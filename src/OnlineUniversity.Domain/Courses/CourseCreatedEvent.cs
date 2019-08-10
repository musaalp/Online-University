using System;

namespace OnlineUniversity.Domain.Courses
{
    public class CourseCreatedEvent : DomainEventBase
    {
        public CourseCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
