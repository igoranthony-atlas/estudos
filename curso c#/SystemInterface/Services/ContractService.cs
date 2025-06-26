using SystemInterface.Entities;

namespace SystemInterface.Services;
class ContractService
{
    private readonly IOnlinePaymentService _onlinePaymentService;

    public ContractService(IOnlinePaymentService onlinePaymentService)
    {
        _onlinePaymentService = onlinePaymentService;
    }

    public void ProcessContract(Contract1 contract, int months)
    {
        double basicQuota = contract.TotalValue / months;

        for (int i = 1; i <= months; i++)
        {
            DateTime dueDate = contract.Date.AddMonths(i);
            double interest = _onlinePaymentService.Interest(basicQuota, i);
            double fee = _onlinePaymentService.PaymentFee(basicQuota + interest);
            double amount = basicQuota + interest + fee;

            contract.Installments.Add(new Installment(dueDate, amount));
        }
    }
}