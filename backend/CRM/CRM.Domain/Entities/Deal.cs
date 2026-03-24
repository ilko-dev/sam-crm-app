using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Deal
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = null!;
        public decimal Amount { get; private set; }
        public Enums.DealStatus Stage { get; private set; }
        public DateTime ExpectedCloseDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int ClientId { get; private set; }
        public Client Client { get; private set; } = null!;
        public int? AssignedUserId { get; private set; }
        public User.User? AssignedUser { get; private set; }
        public string? Description { get; private set; }

        // Private constructor for EF Core
        private Deal() { }

        public Deal(string title, decimal amount, Enums.DealStatus stage,
                   DateTime expectedCloseDate, int clientId, int? assignedUserId = null,
                   string? description = null)
        {
            Title = title;
            Amount = amount;
            Stage = stage;
            ExpectedCloseDate = expectedCloseDate;
            ClientId = clientId;
            AssignedUserId = assignedUserId;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
