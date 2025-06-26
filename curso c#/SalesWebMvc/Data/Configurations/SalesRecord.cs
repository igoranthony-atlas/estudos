using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWebMvc.Entities;

namespace SalesWebMvc.Configurations;

class SalesRecordConfiguration : IEntityTypeConfiguration<SalesRecord>
{
    public void Configure(EntityTypeBuilder<SalesRecord> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Date)
            .IsRequired();
        builder.Property(s => s.Amount)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        builder.Property(s => s.Status)
            .IsRequired()
            .HasConversion<string>();
        builder.HasOne(s => s.Seller)
            .WithMany(d => d.SalesRecords)
            .HasForeignKey(s => s.SellerId);
    }
}
