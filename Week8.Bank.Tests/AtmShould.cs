namespace Week8.Bank.Tests
{
    using System;
    using System.Collections.Generic;
    using Account;
    using Atm;
    using Moq;
    using NUnit.Framework;
    using Printer;
    using Transaction;

    public class AtmShould
    {
        private Mock<IAccount> _accountMock;
        private Mock<IPrinter> _printerMock;

        [SetUp]
        public void Setup()
        {
            _printerMock = new Mock<IPrinter>();
            _accountMock = new Mock<IAccount>();
        }

        [Test]
        public void RequireAnAccountAndAPrinterToBeInstantiated()
        {
            var atmInstance = new Atm(_accountMock.Object, _printerMock.Object);

            Assert.That(atmInstance, Is.Not.Null);
        }

        [Test]
        public void PassTransactionDetailsFromAnAccountToThePrinter()
        {
            var transactions = new List<ITransaction>
            {
                new CreditTransaction(0m, DateTime.Now, 0m)
            };

            _accountMock.Setup(account => account.GetTransactions()).Returns(transactions);

            var atmInstance = new Atm(_accountMock.Object, _printerMock.Object);

            atmInstance.PrintStatement();
            
            _printerMock.Verify(printerMock => printerMock.PrintStatement(transactions));
        }
    }
}