namespace Entities;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }

    public Product(int id, string name, double price, Category category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }
    public override string ToString()
    {
        return $"Product ID: {Id}, Name: {Name}, Price: {Price:C}, Category: {Category.Name}";
    }
}