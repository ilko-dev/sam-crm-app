using CRM.Domain.Enums;

namespace CRM.BLL.DTO.Deal
{
    public class DealDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
        public DealStatus Stage { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public int? AssignedUserId { get; set; }
        public string? AssignedUserName { get; set; }
        public string? Description { get; set; }
    }
}