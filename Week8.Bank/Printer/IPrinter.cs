namespace Week8.Bank.Printer
{
    using System.Collections.Generic;
    using Transaction;

    public interface IPrinter
    {
        string PrintStatement(IEnumerable<ITransaction> account);
    }
}