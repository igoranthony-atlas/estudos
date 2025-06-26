using System.Globalization;

namespace POO;

class ContaBancaria
{
    public string Numero { get; private set; }
    public string Titular { get; set; }
    public double Saldo { get; private set; }

    public ContaBancaria()
    {

    }
    public ContaBancaria(string numero, string titular, double saldoInicial)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
        }
    }

    public void Sacar(double valor)
    {
        if (valor > 0)
        {
            Saldo -= valor;
            Saldo -= 5.00;
        }
    }
    public override string ToString()
    {
        return $"Conta {Numero}, Titular: {Titular}, Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}
/*
        string digitado = "";
        ContaBancaria conta = new ContaBancaria();

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Exibir dados da conta");
            Console.WriteLine("Digite 'sair' para encerrar o programa.");

            switch (digitado = Console.ReadLine().ToLower())
            {
                case "1":
                    Console.Write("Digite o número da conta: ");
                    string numero = Console.ReadLine();
                    Console.Write("Digite o nome do titular: ");
                    string titular = Console.ReadLine();
                    Console.Write("Digite o saldo inicial (opcional): ");
                    string inputSaldo = Console.ReadLine();
                    double saldoInicial = 0.0;
                    if (!string.IsNullOrWhiteSpace(inputSaldo))
                    {
                        saldoInicial = double.Parse(inputSaldo, CultureInfo.InvariantCulture);
                    }
                    conta = new ContaBancaria(numero, titular.Trim(), saldoInicial);
                    Console.WriteLine(conta);
                    break;
                case "2":
                    Console.Write("Digite o valor a depositar: ");
                    double valorDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    conta.Depositar(valorDeposito);
                    Console.WriteLine(conta);

                    break;

                case "3":
                    Console.Write("Digite o valor a sacar: ");
                    double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    conta.Sacar(valorSaque);
                    Console.WriteLine(conta);
                    break;

                case "4":
                    Console.WriteLine(conta.ToString());
                    break;

                case "sair":
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        while (digitado != "sair");
*/