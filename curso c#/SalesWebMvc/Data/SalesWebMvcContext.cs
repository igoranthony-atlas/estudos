using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Configurations;
using SalesWebMvc.Entities;
namespace SalesWebMvc.Data;

public class SalesWebMvcContext : DbContext
{
    public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
        : base(options)
    {
    }

    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<SalesRecord> SalesRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SellerConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new SalesRecordConfiguration());
    }
}