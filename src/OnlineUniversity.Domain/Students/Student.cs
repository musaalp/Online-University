using System;

namespace OnlineUniversity.Domain.Entities
{
    public class Student
    {
        public Student(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
