namespace GenericsSetDicionary;

class Product : IComparable<Product>
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name}, ${Price:F2}";
    }
    public int CompareTo(Product other)
    {
        if (other == null) throw new ArgumentException("Object is not a Product");

        return Price.CompareTo(other.Price);
    }
}