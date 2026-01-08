namespace CRM.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Industry { get; set; }

        public string? Website { get; set; }
        public string? Phone { get; set; }

        public string? Description { get; set; }

        public ICollection<Client> Clients { get; private set; }
        = new List<Client>();
    }
}
