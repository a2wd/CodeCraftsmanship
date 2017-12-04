namespace Week8.Bank.Transaction
{
    using System;

    public class CreditTransaction : ITransaction
    {
        public CreditTransaction(decimal transactionAmount, DateTime date, decimal balance)
        {
            TransactionAmount = transactionAmount;
            Date = date;
            Balance = balance;
        }

        public decimal TransactionAmount { get; }

        public DateTime Date { get; }

        public decimal Balance { get; }
    }
}