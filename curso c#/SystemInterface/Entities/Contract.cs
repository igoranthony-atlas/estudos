namespace SystemInterface.Entities;

public class Contract1
{
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public double TotalValue { get; set; }
    public List<Installment> Installments { get; set; } = new List<Installment>();
    public Contract1()
    {
    }
    public Contract1(int number, DateTime date, double totalValue)
    {
        Number = number;
        Date = date;
        TotalValue = totalValue;
    }
}
/*
Console.WriteLine("Enter contract data");
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Date (dd/MM/yyyy): ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        Console.Write("Contract value: ");
        double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Contract1 contract = new Contract1(number, date, totalValue);

        Console.Write("Enter number of installments: ");
        int months = int.Parse(Console.ReadLine());

        Services.IOnlinePaymentService onlinePaymentService = new Services.PaypalService();
        Services.ContractService contractService = new Services.ContractService(onlinePaymentService);
        
        contractService.ProcessContract(contract, months);

        Console.WriteLine("Installments:");
        foreach (Installment installment in contract.Installments)
        {
            Console.WriteLine(installment);
        }
*/