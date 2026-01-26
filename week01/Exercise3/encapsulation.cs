using System;

class BankAccount
{
    static void Main(string[] args)
    {
    }
    
    private decimal balance;

    public void Deposit(decimal amount)
    {
        if (amount>=0) 
        {
            balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount >=0 && amount <= balance)
        {
            balance -= amount;
        }


    }

    public decimal GetBalance()
    {
        return balance;
    }
}