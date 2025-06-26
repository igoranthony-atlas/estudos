using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWebMvc.Entities;

namespace SalesWebMvc.Configurations;
class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(60);
        builder.HasMany(d => d.Sellers)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DepartmentId);
    }
}