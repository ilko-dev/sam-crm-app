namespace CRM.BLL.DTO.Task
{
    public class CreateUpdateTaskDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedUserId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
