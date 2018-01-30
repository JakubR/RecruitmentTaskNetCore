using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIENN.Domain;

namespace SIENN.DbAccess.EntityConfiguration
{
    public class UnitEntityConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Code)
                .HasMaxLength(128);
            builder.Property(x => x.Code)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}