using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWebMvc.Entities;

namespace SalesWebMvc.Configurations;

class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(60);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(60);
        builder.Property(s => s.BirthDate).IsRequired();
        builder.Property(s => s.BaseSalary).IsRequired();
        builder.HasOne(s => s.Department)
               .WithMany(d => d.Sellers)
               .HasForeignKey(s => s.DepartmentId);
    }
}