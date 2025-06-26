using System.Globalization;
using System.Text;
using Pedidos.Enums;

namespace Pedidos.Entities;

class Order
{
    public int Id { get; set; }
    public DateTime Moment { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public Order() { }
    public Order(int id, DateTime moment, OrderStatus status)
    {
        Id = id;
        Moment = moment;
        Status = status;
    }
    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(OrderItem item)
    {
        Items.Remove(item);
    }
    public double Total()
    {
        double total = 0.0;
        foreach (OrderItem item in Items)
        {
            total += item.SubTotal();
        }
        return total;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Order ID: {Id}");
        sb.AppendLine($"Moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
        sb.AppendLine($"Status: {Status}");
        sb.AppendLine("Order items:");
        foreach (OrderItem item in Items)
        {
            sb.AppendLine($"{item.Product.Name}, ${item.Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {item.Quantity}, Subtotal: ${item.SubTotal().ToString("F2")}");
        }
        sb.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
        return sb.ToString();
    }
}