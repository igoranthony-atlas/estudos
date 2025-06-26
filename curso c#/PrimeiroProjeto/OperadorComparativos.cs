namespace Logica;

class OperadorComparativos
{
    public static void Executar()
    {
        int a = 10;
        bool c1 = a < 10; // false
        bool c2 = a <= 10; // true
        Console.WriteLine($"a < 10: {c1}");
        Console.WriteLine($"a <= 10: {c2}");
    }
}
