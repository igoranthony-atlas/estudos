namespace Logica;
class Condicional
{
    public static void Executar()
    {
        int n1 = int.Parse(Console.ReadLine());
        if (n1 % 2 == 0)
        {
            Console.WriteLine("Número é par!");
        }
        else
        {
            Console.WriteLine("Número é ímpar!");
        }
    }
}