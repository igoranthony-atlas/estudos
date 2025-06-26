namespace Logica;

class For
{
    public static void Executar()
    {
        Console.WriteLine("Quantos numeros você vai querer digitar:");
        int quantidade = int.Parse(Console.ReadLine()!);
        var valorTotal = 0;
        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º numero:");
            var numero = int.Parse(Console.ReadLine()!);
            valorTotal += numero;
        }
        Console.WriteLine($"A soma dos numeros é: {valorTotal}");
    }
}