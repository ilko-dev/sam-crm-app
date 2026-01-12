using CRM.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskModel = CRM.Domain.Entities.Task;

namespace CRM.DAL.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.AssignedUser)
               .WithMany()
               .HasForeignKey(t => t.AssignedUserId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Client)
                   .WithMany(c => c.Tasks)
                   .HasForeignKey(t => t.ClientId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(t => t.Status);
            builder.HasIndex(t => t.AssignedUserId);
        }
    }
}
