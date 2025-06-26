namespace SalesWebMvc.Entities;

public class Seller
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public IEnumerable<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();
}