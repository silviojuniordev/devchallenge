using Dev.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Challenge.Data.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.RegisterDate)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasMany(p => p.Tasks)
                .WithOne(p => p.Project)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
