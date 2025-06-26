using System.Globalization;
using Pedidos.Entities;
using Pedidos.Enums;

namespace Pedidos;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter client data:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Birth date (DD/MM/YYYY): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        Client client = new Client(name, email, birthDate);

        Console.WriteLine("Enter order data:");
        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Order order = new Order(1, DateTime.Now, status);

        Console.Write("How many items to this order? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} item data:");
            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Product product = new Product(productName, productPrice);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderItem orderItem = new OrderItem(quantity, product);
            order.AddItem(orderItem);
        }

        Console.WriteLine();
        Console.WriteLine("ORDER SUMMARY:");
        Console.WriteLine(client);
        Console.WriteLine(order);
    }
}