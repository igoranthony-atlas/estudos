using Excecoes.Exceptions;

namespace Excecoes.Entities;

class Account
{
    public int Number { get; private set; }
    public string Holder { get; private set; }
    public double Balance { get; private set; }
    public double WithdrawLimit { get; private set; }

    public Account(int number, string holder, double withdrawLimit)
    {
        Number = number;
        Holder = holder;
        WithdrawLimit = withdrawLimit;
        Balance = 0.0;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
    }
    public void Withdraw(double amount)
    {
        if (amount > WithdrawLimit)
        {
            throw new DomainException("The amount exceeds withdraw limit");
        }
        if (amount > Balance)
        {
            throw new DomainException("Not enough balance");
        }
        Balance -= amount;
    }
}
/*
try
        {
            Console.Write("Enter account number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter account holder: ");
            string holder = Console.ReadLine();
            Console.Write("Enter withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine());

            Account account = new Account(number, holder, withdrawLimit);

            Console.Write("Enter amount for deposit: ");
            double depositAmount = double.Parse(Console.ReadLine());
            account.Deposit(depositAmount);

            Console.Write("Enter amount for withdraw: ");
            double withdrawAmount = double.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);

            Console.WriteLine($"New balance: {account.Balance}");
        }
        catch (DomainException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid input format. Please enter numeric values.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Thank you for using our service!");
        }   
        */