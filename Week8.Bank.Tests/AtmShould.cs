namespace Week8.Bank.Tests
{
    using System;
    using System.Collections.Generic;
    using Account;
    using Atm;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Internal.Commands;
    using Printer;
    using Transaction;

    public class AtmShould
    {
        private Mock<IAccount> _accountMock;
        private Mock<IPrinter> _printerMock;
        private Atm _atmInstance;

        [SetUp]
        public void Setup()
        {
            _printerMock = new Mock<IPrinter>();
            _accountMock = new Mock<IAccount>();

            _atmInstance = new Atm(_accountMock.Object, _printerMock.Object);
        }

        [Test]
        public void RequireAnAccountAndAPrinterToBeInstantiated()
        {

            Assert.That(_atmInstance, Is.Not.Null);
        }

        [Test]
        public void PassTransactionDetailsFromAnAccountToThePrinter()
        {
            var transactions = new List<ITransaction>
            {
                new Transaction(0m, DateTime.Now, 0m)
            };

            _accountMock.Setup(account => account.GetTransactions()).Returns(transactions);

            _atmInstance.PrintStatement();
            
            _printerMock.Verify(printerMock => printerMock.PrintStatement(transactions));
        }

        [Test]
        public void AllowTransactionToBeAddedToAccount()
        {
            var creditTransaction = new Transaction(0m, DateTime.Now, 0m);
            
            _atmInstance.AddTransactionToAccount(creditTransaction);

            _accountMock.Verify(account => account.AddTransaction(creditTransaction));
        }

        [Test]
        public void KeepARunningTotalOfTheBalanceWhenDepositingMoneyInAnAccount()
        {
            var creditAmount = 55.25m;

            decimal newBalance = 0m;

            _accountMock.Setup(account => account.AddTransaction(It.IsAny<ITransaction>()))
                .Callback<ITransaction>(transaction => newBalance = transaction.GetBalance());

            _atmInstance.MakeADeposit(creditAmount);

            Assert.That(newBalance, Is.EqualTo(creditAmount));
        }
    }
}