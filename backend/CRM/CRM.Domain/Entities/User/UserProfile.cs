namespace CRM.Domain.Entities.User
{
    public class UserProfile
    {
        public int UserId { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string? Phone { get; private set; }
        //public string Language { get; private set; } = "en";
        //public string Theme { get; private set; } = "light";
        public User User { get; private set; } = null!;
        private UserProfile() { }
        public UserProfile(int userId, string firstName, string lastName, string? phone)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

    }
}
