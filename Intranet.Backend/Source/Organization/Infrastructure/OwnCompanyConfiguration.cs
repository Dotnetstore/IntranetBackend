using Domain.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Organization.Infrastructure;

internal sealed class OwnCompanyConfiguration : IEntityTypeConfiguration<OwnCompany>
{
    public void Configure(EntityTypeBuilder<OwnCompany> builder)
    {
        builder
            .HasKey(q => q.ID);

        builder
            .Property(q => q.ID)
            .IsRequired();

        builder
            .Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(true)
            .HasColumnType("nvarchar");

        builder
            .Property(q => q.CreatedDate)
            .IsRequired();

        builder
            .Property(q => q.VATNumber)
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnType("varchar");
    }
}