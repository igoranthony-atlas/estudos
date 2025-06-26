using System.Globalization;

namespace Logica;
class Enquanto
{
    public static void Executar()
    {
        double numero = 0.0;
        do
        {
            double numeroInteiro = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double raizQuadrada = Math.Sqrt(numeroInteiro);
            if (raizQuadrada < 0)
            {
                Console.WriteLine("Número negativo.");
                break;
            }
            Console.WriteLine($"Raiz quadrada de {numeroInteiro} é {raizQuadrada}");
            numero += raizQuadrada;
        } while (numero > 0.0);
    }
}