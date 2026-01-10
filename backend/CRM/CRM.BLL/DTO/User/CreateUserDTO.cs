using CRM.Domain.Enums;

namespace CRM.BLL.DTO.User
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
