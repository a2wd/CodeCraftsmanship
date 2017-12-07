namespace Week8.Bank.Transaction
{
    using System;

    public interface ITransaction
    {
        decimal GetTransactionAmount();
        DateTime GetDate();
        decimal GetBalance();
    }
}