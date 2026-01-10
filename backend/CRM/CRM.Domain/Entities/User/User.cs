using CRM.Domain.Enums;

namespace CRM.Domain.Entities.User
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public UserProfile Profile { get; private set; } = null!;

        private User() { }
        public User(string email, string passwordHash, UserRole role)
        {
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }
        public void AttachProfile(UserProfile profile)
        {
            Profile = profile;
        }
    }
}
