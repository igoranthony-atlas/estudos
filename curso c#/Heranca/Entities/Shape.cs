namespace Heranca.Entities;

abstract class Shape
{
    public string Color { get; set; }
    public Shape()
    {
    }

    public Shape(string color)
    {
        Color = color;
    }
    public abstract double Area();
}
/*
        Console.Write("Enter the number of shapes: ");
        int n = int.Parse(Console.ReadLine());
        Shape[] shapes = new Shape[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Shape #{i + 1} data:");
            Console.Write("Rectangle or Circle (r/c)? ");
            char ch = char.Parse(Console.ReadLine());
            Console.Write("Color: ");
            string color = Console.ReadLine();

            if (ch == 'r')
            {
                Console.Write("Width: ");
                double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Height: ");
                double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                shapes[i] = new Rectangle(color, width, height);
            }
            else
            {
                Console.Write("Radius: ");
                double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                shapes[i] = new Circle(color, radius);
            }
        }
        Console.WriteLine();
        Console.WriteLine("SHAPES AREAS:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Area().ToString("F2"));
        }
*/