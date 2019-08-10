using OnlineUniversity.Domain.Entities;
using OnlineUniversity.Domain.Students;
using System;
using System.Collections.Generic;

namespace OnlineUniversity.Domain.Courses
{
    public class Course : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string LecturerId { get; set; }

        public Course(string name, int capacity, string lecturerId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Capacity = capacity;
            LecturerId = lecturerId;

            AddDomainEvent(new CourseCreatedEvent(Id, Name));
        }

        public Course SignUpStudent(Student student)
        {
            Students.Add(student);

            AddDomainEvent(new StudentSignedUpEvent(student.Id, student.Email));

            return this;
        }

        public Lecturer Lecturer { get; set; }
        public ICollection<Student> Students { get; private set; } = new List<Student>();
    }
}
