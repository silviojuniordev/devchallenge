using Dev.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Challenge.Data.Mappings
{
    public class TaskingMapping : IEntityTypeConfiguration<Tasking>
    {
        public void Configure(EntityTypeBuilder<Tasking> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.MaturityDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.RegisterDate)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(x => x.AssignedUser)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(p => p.TaskComments)
                .WithOne(p => p.Tasking)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
