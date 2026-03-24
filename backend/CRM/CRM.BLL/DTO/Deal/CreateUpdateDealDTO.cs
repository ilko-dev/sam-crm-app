using CRM.Domain.Enums;

namespace CRM.BLL.DTO.Deal
{
    public class CreateUpdateDealDTO
    {
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
        public DealStatus Stage { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ClientId { get; set; }
        public int? AssignedUserId { get; set; }
        public string? Description { get; set; }
    }
}