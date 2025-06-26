namespace SystemInterface.Services;
class PaypalService : IOnlinePaymentService
{
    private const double InterestRate = 0.02;
    private const double PaymentFeeRate = 0.01;

    public double Interest(double amount, int months)
    {
        return amount * InterestRate * months;
    }

    public double PaymentFee(double amount)
    {
        return amount * PaymentFeeRate;
    }
}