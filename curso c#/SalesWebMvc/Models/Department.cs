namespace SalesWebMvc.Entities;

public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<Seller> Sellers { get; set; } = new List<Seller>();
}