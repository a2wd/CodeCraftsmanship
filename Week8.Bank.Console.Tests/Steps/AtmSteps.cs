using System;
using TechTalk.SpecFlow;

namespace Week8.Bank.Console.Tests.Steps
{
    using System.Text;
    using Atm;
    using NUnit.Framework;

    [Binding]
    public class AtmSteps
    {
        private string atmOutput;

        private IAtm _atm;

        public AtmSteps()
        {
           
            var account = new Account();
            _atm = new Bank.Atm(account);
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(decimal depositAmount, string transactionDate)
        {
            _atm.Deposit(depositAmount, transactionDate);
        }
        
        [Given(@"a client makes a withdrawal of (.*) on (.*)")]
        public void GivenAClientMakesAWithdrawalOfOn(decimal withdrawalAmount, string transactionDate)
        {
            _atm.Withdraw(withdrawalAmount, transactionDate);
        }
        
        [When(@"the client prints their statement")]
        public void WhenTheClientPrintsTheirStatement()
        {
            atmOutput = _atm.PrintStatement();
        }
        
        [Then(@"they would see the expected statement")]
        public void ThenTheyWouldSeeTheExpectedStatement()
        {
            var expectedAtmOutput = new StringBuilder();
            expectedAtmOutput.AppendLine("date       || credit || debit || balance");
            expectedAtmOutput.AppendLine("14/01/2012 ||        || 5.00  || 25.00  ");
            expectedAtmOutput.AppendLine("13/01/2012 || 20.00  || 5.00  || 30.00  ");
            expectedAtmOutput.AppendLine("10/01/2012 || 10.00  || 5.00  || 10.00  ");

            Assert.That(atmOutput, Is.EqualTo(expectedAtmOutput.ToString()));
        }
    }
}
