using System;

namespace BankingSystem
{
    public class CheckingAccount : IBankAccount
    {
        private const char CurrentAccount = 'C';

        private decimal _balance;

        public IBankAccount ObjBankAccount { get; }

        public CheckingAccount(IBankAccount objBankAccount)
        {
            ObjBankAccount = objBankAccount;
        }

        public CheckingAccount()
        {
        }


        public bool Deposit(decimal amount, User user)
        {
            if (amount > 10000 || amount < 0)
            {
                Console.WriteLine($"Cannot deposit {amount} to your account at one time. Please Enter a valid amount.");
                return false;
            }

            _balance += amount;

            user.GetAccountBalance = _balance;

            Console.WriteLine("Amount Deposited to your Current Account");

            return true;
        }
        public bool Withdraw(decimal amount, User user)
        {
            if (_balance < amount)
            {
                Console.WriteLine("Insufficient balance!");
                return false;
            }

            if (amount > (decimal)(0.9 * (double)Balance) ||  amount > 100)
            {
                Console.WriteLine("Withdrawal attempt failed. Please enter a Valid withdrawal amount!");
                return false;
            }
            else
            {
                _balance -= amount;
                user.GetAccountBalance = _balance;

                Console.WriteLine($"Successfully withdrawn: {amount,6:C}");

                return true;
            }
        }
        public decimal Balance => _balance;

        public override string ToString()
        {
            return $"Current Account Balance = {_balance, 6:C}";
        }

        public int CreateAccount(User customer)
        {
            var getAccountNo = new Random();

            var details = new AccountDetails
            {
                AccountNo = getAccountNo.Next(),
                AccountType = CurrentAccount,
                GetAccountBalance = Balance
            };

            // Updating the number of accounts for a user.
            customer.UserAccount.Add(details);

            return details.AccountNo;
        }
    }
}
