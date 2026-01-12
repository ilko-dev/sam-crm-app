namespace CRM.Domain.Entities
{
    public class Task
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Enums.TaskStatus Status { get; private set; }
        public int? AssignedUserId { get; private set; }
        public int? ClientId { get; private set; }

        public Entities.User.User? AssignedUser { get; private set; }
        public Client? Client { get; private set; }

    }
}
