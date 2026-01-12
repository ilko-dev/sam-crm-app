namespace CRM.Domain.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string? Phone { get; private set; }
        public int? CompanyId { get; private set; }
        public Company? Company { get; private set; } = null;
        public DateTime CreatedAt { get; private set; }

        public ICollection<Task> Tasks { get; private set; }
        = new List<Task>();
    }
}
