namespace Logica;

using System;
class EntradaDeDadosPt1
{
    public static void Executar()
    {
        string frase = Console.ReadLine();
        string x = Console.ReadLine();
        string y = Console.ReadLine();
        string z = Console.ReadLine();

        string[] vet = Console.ReadLine().Split(' ');

        string p1 = vet[0];
        string p2 = vet[1];
        string p3 = vet[2];

        Console.WriteLine(frase);
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(z);
        Console.Write(p1);
        Console.Write(p2);
        Console.Write(p3);
    }
}