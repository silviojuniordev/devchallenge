using Dev.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Challenge.Data.Mappings
{
    public class HistoryMapping : IEntityTypeConfiguration<Historic>
    {
        public void Configure(EntityTypeBuilder<Historic> builder)
        {
            builder.ToTable("Historic");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OldField)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(x => x.NewField)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(x => x.OperationType)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.RegisterDate)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.User)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
