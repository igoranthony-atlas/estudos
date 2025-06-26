using System.Globalization;

namespace POO;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; private set; }
    public int Quantidade { get; private set; }

    public Produto()
    {
        Quantidade = 10;
    }
    public Produto(string nome, double preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }
    
    public double ValorTotalEmEstoque()
    {
        return Preco * Quantidade;
    }

    public void AdicionarProdutos(int quantidade)
    {
        Quantidade += quantidade;
    }

    public void RemoverProdutos(int quantidade)
    {
        Quantidade -= quantidade;
    }

    public override string ToString()
    {
        return $"{Nome}, R$ {Preco.ToString("F2", CultureInfo.InvariantCulture)}, {Quantidade} unidades, Total: R$ {ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}
/* EXERCICIO DE PRODUTOS
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço do produto: ");
        double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Digite a quantidade do produto: ");
        int quantidade = int.Parse(Console.ReadLine());
        Produto p = new Produto(nome, preco, quantidade);

        Console.WriteLine("Dados do produto: " + p);

        Console.Write("Digite o número de produtos a serem adicionados ao estoque: ");
        int quantidadeAdicionar = int.Parse(Console.ReadLine());
        p.AdicionarProdutos(quantidadeAdicionar);
        Console.WriteLine("Dados atualizados: " + p);
        
        Console.Write("Digite o número de produtos a serem removidos do estoque: ");
        int quantidadeRemover = int.Parse(Console.ReadLine());
        p.RemoverProdutos(quantidadeRemover);
        Console.WriteLine("Dados atualizados: " + p);
        */