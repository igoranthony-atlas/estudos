namespace Logica;

using System;
using System.Globalization;

class EntradaDeDadosPt2
{
    public static void Executar()
    {
        int n1 = int.Parse(Console.ReadLine());
        char letra = char.Parse(Console.ReadLine());
        double n2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        string[] vet = Console.ReadLine().Split(' ');

        string nome = vet[0];
        char sexo = char.Parse(vet[1]);
        int idade = int.Parse(vet[2]);
        double altura = double.Parse(vet[3], CultureInfo.InvariantCulture);

        Console.WriteLine(n1);
        Console.WriteLine(letra);
        Console.WriteLine(n2.ToString("F1"));
        
        Console.WriteLine($"{nome} {sexo} {idade} {altura:F2}");
    }
}