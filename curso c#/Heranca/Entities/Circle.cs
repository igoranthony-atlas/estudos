namespace Heranca.Entities;
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle()
    {
    }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}