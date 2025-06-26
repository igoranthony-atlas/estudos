namespace  POO;

class Triangulo
{
    public double A;
    public double B;
    public double C;

    public double Area()
    {
        double p = (A + B + C) / 2.0;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

}
        /* 
                                        EXERCICIO DE TRIANGULOS
        Triangulo x, y; 
        x = new Triangulo();
        y = new Triangulo();

        Console.WriteLine("Digite os lados do triângulo X:");
        x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("Digite os lados do triângulo Y:");
        y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("Área do triângulo X: " + x.Area().ToString("F4", CultureInfo.InvariantCulture));
        Console.WriteLine("Área do triângulo Y: " + y.Area().ToString("F4", CultureInfo.InvariantCulture));
        */