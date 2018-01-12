namespace Week8.Bank.Atm
{
    using System;
    using System.Linq;
    using Account;
    using Printer;
    using Transaction;

    public class Atm : IAtm
    {
        private readonly IAccount _account;
        private readonly IPrinter _printer;

        public Atm(IAccount account, IPrinter printer)
        {
            _account = account;
            _printer = printer;
        }

        public void PrintStatement()
        {
            var transactions = _account.GetTransactions();
            _printer.PrintStatement(transactions);
        }

        public void AddTransactionToAccount(ITransaction creditTransaction)
        {
            _account.AddTransaction(creditTransaction);
        }

        public void MakeADeposit(decimal creditAmount)
        {
            var newBalance = GetBalance() + creditAmount;

            _account.AddTransaction(new Transaction(creditAmount, DateTime.UtcNow, newBalance));
        }

        public decimal GetBalance()
        {
            var latestTransaction = _account.GetTransactions().OrderBy(transaction => transaction.GetDate()).Last();

            return latestTransaction.GetBalance();
        }

        public void MakeAWithdrawal(decimal debitAmount)
        {
            var newBalance = GetBalance() - debitAmount;

            _account.AddTransaction(new Transaction(-debitAmount, DateTime.UtcNow, newBalance));
        }
    }
}