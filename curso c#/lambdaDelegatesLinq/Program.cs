using System.Globalization;
using Entities;
using Service;

namespace program;

class ProductExercicio
{
    public string Name { get; set; }
    public double Price { get; set; }

    public ProductExercicio(string name, double price)
    {
        Name = name;
        Price = price;
    }
    public override string ToString()
    {
        return $"Product Name: {Name}, Price: {Price:C}";
    }
}
class Program
{

    static void Main(string[] args)
    {
        //pegar arquivo
        string filePath = "c:\\temp\\arquivolog.txt";
        List<ProductExercicio> products = new List<ProductExercicio>();
        using (StreamReader sr = File.OpenText(filePath))
        {
            while (!sr.EndOfStream)
            {
                string[] fields = sr.ReadLine().Split(',');
                if (fields.Length == 2)
                {
                    string name = fields[0].Trim();
                    double price = double.Parse(fields[1].Trim(), CultureInfo.InvariantCulture);
                    products.Add(new ProductExercicio(name, price));
            
                }
                else
                {
                    Console.WriteLine("Invalid line format: " + sr.ReadLine());
                }
            }
        }
        var r1 = products
        .Average(p => p.Price);
        var r2 = products
        .Select(p => p.Name);

        Console.WriteLine("Average Price: " + r1.ToString("C"));
        Console.WriteLine("Products:");
        foreach (var product in r2)
        {
            Console.WriteLine(product);
        }
    }
}