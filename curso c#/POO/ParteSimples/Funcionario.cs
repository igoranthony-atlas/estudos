using System.Globalization;

namespace POO;

class Funcionario
{
    public string Nome;
    public double Salario;
    public double Imposto;

    public double AumentarSalario(double porcentagem)
    {
        Salario += Salario * (porcentagem / 100);
        return Salario;
    }
    public double SalarioLiquido()
    {
        return Salario - Imposto;
    }
    public override string ToString()
    {
        return $"{Nome}, R$ {SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}
/* EXERCICIO DE FUNCIONARIO
        Funcionario f = new Funcionario();
        Console.Write("Digite o nome do funcionário: ");
        f.Nome = Console.ReadLine();
        Console.Write("Digite o salário do funcionário: ");
        f.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Digite o imposto do funcionário: ");
        f.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Funcionário: " + f);
        Console.Write("Digite a porcentagem do aumento salarial: ");
        double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        f.AumentarSalario(porcentagem);
        Console.WriteLine("Dados atualizados: " + f);
        */