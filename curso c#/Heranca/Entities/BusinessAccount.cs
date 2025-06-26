namespace Heranca.Entities;

class BusinessAccount : Account
{
    public double LoanLimit { get; set; }

    public BusinessAccount()
    {
    }

    public BusinessAccount(int number, string holder, double balance, double loanLimit) //recebe os parametros do construtor
        : base(number, holder, balance) //chama o construtor da classe Account
    {
        LoanLimit = loanLimit;
    }

    public void Loan(double amount)
    {
        //verifica se a quantidade solicitada é menor ou igual ao limite de empréstimo
        if (amount <= LoanLimit)
        {
            Balance += amount;
        }
    } 
}
