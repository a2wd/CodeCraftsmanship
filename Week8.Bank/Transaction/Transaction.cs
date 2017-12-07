namespace Week8.Bank.Transaction
{
    using System;

    public class Transaction: ITransaction
    {
        private readonly decimal _transactionAmount;
        private readonly DateTime _transactionDate;
        private readonly decimal _balance;

        public Transaction(decimal transactionAmount, DateTime transactionDate, decimal balance)
        {
            _transactionAmount = transactionAmount;
            _transactionDate = transactionDate;
            _balance = balance;
        }

        public decimal GetTransactionAmount()
        {
            return _transactionAmount;
        }

        public DateTime GetDate()
        {
            return _transactionDate;
        }

        public decimal GetBalance()
        {
            return _balance;
        }
    }
}
