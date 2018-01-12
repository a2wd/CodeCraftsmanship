namespace Week8.Bank.Tests
{
    using System;
    using System.Linq;
    using Account;
    using NUnit.Framework;
    using Transaction;

    [TestFixture]
    public class AccountShould
    {
        private IAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new Account();
        }

        [Test]
        public void ReturnAnEmptyListOfTransactionsWhenNoTransactionHaveBeenAdded()
        {
            var transactionList = _account.GetTransactions();

            Assert.That(transactionList, Is.Not.Null);
        }

        [Test]
        public void AllowATransactionToBeAdded()
        {
            _account.AddTransaction(new Transaction(0m, DateTime.UtcNow, 0m));

            var transactionList = _account.GetTransactions();

            Assert.That(transactionList, Is.Not.Null);
            Assert.That(transactionList.Count(), Is.EqualTo(1));
        }
    }
}