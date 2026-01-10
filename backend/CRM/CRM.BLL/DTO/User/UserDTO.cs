using CRM.Domain.Enums;

namespace CRM.BLL.DTO.User
{
    public class UserDTO
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = null!;
        public UserRole Role { get; private set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
