﻿namespace Week8.Bank.Atm
{
    using Transaction;

    public interface IAtm
    {
        void PrintStatement();
        void AddTransactionToAccount(ITransaction creditTransaction);
        void MakeAWithdrawal(decimal debitAmount);
        void MakeADeposit(decimal creditAmount);
    }
}