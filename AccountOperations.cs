using System;

namespace BankingSystem
{
    public static class AccountOperations
    {
        public static IBankAccount CurrentAccount { get; } = new CheckingAccount();
        public static IBankAccount SavingsAccount { get; } = new SavingAccount();

        public static void SetupAnAccount(ref User user, char accountType)
        {
            if (accountType.Equals('C'))
            {
                CurrentAccount.CreateAccount(user);
            }
            else if (accountType.Equals('S'))
            {
                SavingsAccount.CreateAccount(user);
            }
            else
            {
                Console.WriteLine("Please enter a valid Account Type!");
            }

            Console.WriteLine("Bank Account Created Successfully!");
        }

        public static void DepositToYourAccount(ref User userAccount, decimal amount, char accounttType)
        {
            if (accounttType.Equals('C'))
            {
                CurrentAccount.Deposit(amount, userAccount);
                
            }
            else if (accounttType.Equals('S'))
            {
                SavingsAccount.Deposit(amount, userAccount);
                
            }
        }

        public static void WithdrawBalance(ref User userAccount, decimal amount, char accounttType)
        {
            switch (accounttType)
            {
                case 'C':
                {
                    CurrentAccount.Withdraw(amount, userAccount);
                    Console.WriteLine("Amount Withdrawn from your Current Account");
                    break;
                }
                case 'S':
                {
                    SavingsAccount.Withdraw(amount, userAccount);
                    Console.WriteLine("Amount Withdrawn from your Current Account");
                    break;
                }
            }
        }

        public static void CheckBalance(ref User account, char accounttType)
        {
            switch (accounttType)
            {
                case 'C':
                {
                    Console.WriteLine($"Your Current Account Balance is {CurrentAccount.Balance}");

                    break;
                }
                case 'S':
                {
                   Console.WriteLine($"Your Current Account Balance is {SavingsAccount.Balance}");

                    break;
                }
            }
        }
    }
}
