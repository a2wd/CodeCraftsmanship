namespace Week8.Bank.Account
{
    using System.Collections.Generic;
    using Transaction;

    public interface IAccount
    {
        void AddTransaction(ITransaction transaction);
        IEnumerable<ITransaction> GetTransactions();
        decimal GetBalance();
    }
}