namespace Logica;

class Funcoes
{
    public static void Executar()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());

        int maior = Maior(n1, n2, n3);
        Console.WriteLine($"O maior número é: {maior}");
    }
    static int Maior(int n1, int n2, int n3)
    {
        int maior = n1;

        if (n2 > maior)
        {
            maior = n2;
        }
        if (n3 > maior)
        {
            maior = n3;
        }

        return maior;
    }

}