using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem
{
    public class SavingAccount : IBankAccount
    {
        private const char SavingsAccount = 'S';

        private decimal _balance;

        public IBankAccount ObjBankAccount { get; }

        public SavingAccount(IBankAccount objBankAccount)
        {
            ObjBankAccount = objBankAccount;
        }
        public SavingAccount()
        {
        }

        private decimal _dailyLimit;
        public bool Deposit(decimal amount, User user)
        {
            if (amount > 10000)
            {
                Console.WriteLine($"Cannot deposit {amount} to your account at one time.");
            }

            _balance += amount;

            user.GetAccountBalance = _balance;

            return true;
        }

        public bool Withdraw(decimal amount, User user)
        {
            if (_balance < amount)
            {
                Console.WriteLine("Insufficient balance!");
                return false;
            }

            if (amount > (decimal)(0.9 * (double)(_dailyLimit+amount)) || _dailyLimit + amount < 100)
            {
                Console.WriteLine("Withdrawal attempt failed. Please enter a Valid withdrawal amount!");
                return false;
            }
            else
            {
                _balance -= amount;
                _dailyLimit += amount;
                user.GetAccountBalance = _balance;
                Console.WriteLine($"Successfully withdrawn: {amount, 6:C}");

                return true;
            }
        }

        public decimal Balance => _balance;

        public override string ToString()
        {
            return $"Saving Account Balance = {_balance, 6:C}";
        }

        public int CreateAccount(User customer)
        {
            var rnd = new Random();
            var details = new AccountDetails
            {
                AccountNo = rnd.Next(),
                AccountType = SavingsAccount
            };

            // Updating the number of accounts for a user.
            customer.UserAccount.Add(details);

            return details.AccountNo;
        }
    }
}
