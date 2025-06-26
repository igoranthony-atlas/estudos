namespace Heranca.Entities;

sealed class SavingsAccount : Account
{
    public double InterestRate { get; set; }

    public SavingsAccount()
    {
    }

    public SavingsAccount(int number, string holder, double balance, double interestRate) //recebe os parametros do construtor
        : base(number, holder, balance) //chama o construtor da classe Account
    {
        InterestRate = interestRate;
    }
    public void UpdateBalance()
    {
        Balance += Balance * InterestRate;
    }
    public override void Withdraw(double amount)
    {
        base.Withdraw(amount); // chama o método Withdraw da classe base Account
        Balance -= 2.0;     // aplica uma taxa de 2.0 ao saque
    }
}