namespace Week8.Bank.Account
{
    using System;
    using System.Collections.Generic;
    using Transaction;

    public class Account : IAccount
    {
        private readonly List<ITransaction> _transactions;

        public Account()
        {
            _transactions = new List<ITransaction>();
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public IEnumerable<ITransaction> GetTransactions()
        {
            return _transactions;
        }

        public decimal GetBalance()
        {
            throw new System.NotImplementedException();
        }
    }
}