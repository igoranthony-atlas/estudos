namespace SystemInterface;

class Invoice
{
    public double BasicPayment { get; set; }
    public double Tax { get; set; }
    public Invoice(double basicPayment, double tax)
    {
        BasicPayment = basicPayment;
        Tax = tax;
    }
    public double TotalPayment
    {
        get { return BasicPayment + Tax; }
    }
    public override string ToString()
    {
        return "Basic Payment: " + BasicPayment.ToString("F2") + "\n" +
               "Tax: " + Tax.ToString("F2") + "\n" +
               "Total Payment: " + TotalPayment.ToString("F2");
    }
}