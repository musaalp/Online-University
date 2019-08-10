namespace OnlineUniversity.Domain.Entities
{
    public class Lecturer
    {
        public Lecturer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
