using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<User>();
            IBankAccount currentAccount = new CheckingAccount();
            IBankAccount savingAccount = new SavingAccount();


            while (true)
            {
                Console.Write("1. Set up your account\n" +
                              "2. Check your balance\n" +
                              "3. Deposit to Account \n" +
                              "4. Withdraw from Account \n" +
                              "X. Terminate\n\nSelect an option from menu: ");

                var options = Console.ReadLine()?.ToUpper();

                Console.WriteLine("\n");

                switch (options)
                {
                    case "1":
                        Console.WriteLine("Please Enter below details!");

                        Console.WriteLine("Enter your id: ");
                        var id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter your FirstName: ");
                        var firstName = Console.ReadLine();

                        Console.WriteLine("Enter your LastName: ");
                        var lastName = Console.ReadLine();

                        Console.WriteLine("Enter your Mail id: ");
                        var mailId = Console.ReadLine();

                        Console.WriteLine("Enter your Phone No: ");
                        var phoneNo = Convert.ToInt64(Console.ReadLine());

                        var customer = new User(id, firstName, lastName, mailId, phoneNo);

                        Console.WriteLine("Enter an account type to be created Current or Savings (C/S)!");
                        var accountType = Convert.ToChar(Console.ReadLine().ToUpper());

                        AccountOperations.SetupAnAccount(ref customer, accountType);
                        accounts.Add(customer);
                        break;

                    case "2":
                        AccountOperations.GetAccountBalance(accounts , out bool isAccount);
                        if (!isAccount)
                        {
                            Console.WriteLine("User Account doesn't exist!");
                        }

                        break;

                    case "3":
                        AccountOperations.DepositToYourAccount(accounts, currentAccount, savingAccount);
                        Console.WriteLine();

                        break;

                    case "4":
                        AccountOperations.WithdrawBalance(accounts, currentAccount, savingAccount);

                        Console.WriteLine();

                        break;

                    case "x": 
                        break;

                    default:
                        Console.WriteLine("Not a valid selection!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
