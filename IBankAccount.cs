using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public interface IBankAccount
    {
        int CreateAccount(User customer);
        bool Deposit(decimal amount, User customer);
        bool Withdraw(decimal amount, User customer);
        decimal Balance { get; }
    }
}
