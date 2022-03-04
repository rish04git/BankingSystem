using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem
{
    public static class AccountOperations
    {
        public static void SetupAnAccount(ref User user, char accountType)
        {
            if (accountType.Equals('C'))
            {
                IBankAccount currentAccount = new CheckingAccount();
                currentAccount.CreateAccount(user);
            }
            else if (accountType.Equals('S'))
            {
                IBankAccount savingAccount = new SavingAccount();
                savingAccount.CreateAccount(user);
            }
            else
            {
                Console.WriteLine("Please enter a valid Account Type!");
            }

            Console.WriteLine("Bank Account Created Successfully!");

            Console.ReadLine();
        }

        public static decimal GetAccountBalance(List<User> customerList, out bool isAccount)
        {
            Console.WriteLine("Enter your User Id.");
            var id = int.Parse(Console.ReadLine());
            decimal balance = 0;
            isAccount = false;
            foreach (var userAccount in customerList.Where(userAccount => userAccount.UserId == id))
            {
                isAccount = true;
                Console.WriteLine("Account Found!\nName: {0}\nBalance: {1}", userAccount.UserId, userAccount.GetAccountBalance);
                balance =  userAccount.GetAccountBalance;
            }

            return balance;
        }

        public static void DepositToYourAccount(List<User> customerList, IBankAccount currentAccount, IBankAccount savingAccount)
        {
            Console.Write("Enter your user ID: ");
            var userId = int.Parse(Console.ReadLine());
            var checkId = false;

            foreach (var userAccount in customerList.Where(userAccount => userAccount.UserId == userId))
            {
                checkId = true;
                Console.Write("Enter the Account Type to deposit (C/S): ");
                var accountType = Convert.ToChar(Console.ReadLine().ToUpper());

                Console.Write("Enter the amount to be deposited : ");

                var amount = decimal.Parse(Console.ReadLine());

                if (userAccount.AccountType == accountType)
                {
                    currentAccount.Withdraw(amount, userAccount);
                }
                else
                {
                    savingAccount.Deposit(amount, userAccount);

                }
            }

            if (checkId == false)
            {
                Console.WriteLine("No such User id exists.");
            }
        }

        public static void WithdrawBalance(List<User> customerList, IBankAccount currentAccount, IBankAccount savingAccount)
        {
            Console.Write("Enter your user ID: ");
            var userID = int.Parse(Console.ReadLine());
            bool checkUId = false;

            foreach (var userAccount in customerList.Where(userAccount => userAccount.UserId == userID))
            {
                checkUId = true;
                Console.Write("Enter the Account Type to withdraw (C/S): ");
                var accountType = Convert.ToChar(Console.ReadLine().ToUpper());

                Console.Write("Enter the amount to be withdrawn : ");

                var amount = decimal.Parse(Console.ReadLine());
                if (userAccount.AccountType == accountType)
                {
                    currentAccount.Withdraw(amount, userAccount);
                }
                else
                {
                    savingAccount.Withdraw(amount, userAccount);
                }
            }

            if (checkUId == false)
            {
                Console.WriteLine("No such User id exists.");
            }
        }

    }
}
