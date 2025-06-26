namespace Heranca.Entities;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product()
    {
    }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual string PriceTag()
    {
        return $"{Name} $ {Price:F2}";
    }
}
/*
        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());
        Product[] products = new Product[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Product #{i + 1} data:");
            Console.Write("Common, used or imported (c/u/i)? ");
            char type = char.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);

            if (type == 'c')
            {
                products[i] = new Product(name, price);
            }
            else if (type == 'u')
            {
                Console.Write("Manufacture date (DD/MM/YYYY): ");
                DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                products[i] = new UsedProduct(name, price, manufactureDate);
            }
            else
            {
                Console.Write("Customs fee: ");
                double customsFee = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                products[i] = new ImportedProduct(name, price, customsFee);
            }
        }
        Console.WriteLine();
        Console.WriteLine("PRICE TAGS:");
        foreach (Product product in products)
        {
            Console.WriteLine(product.PriceTag());
        }
*/