using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<User>();


            while (true)
            {
                Console.Write("1. Set up your account\n" +
                              "2. Check your balance\n" +
                              "3. Deposit to Account \n" +
                              "4. Withdraw from Account \n" +
                              "X. Terminate\n\nSelect an option from menu: ");

                var options = Console.ReadLine()?.ToUpper();

                Console.WriteLine("\n");

                int userId;
                bool checkId;
                switch (options)
                {
                    case "1":
                        Console.WriteLine("Please Enter below details!");

                        Console.WriteLine("Enter your id: ");
                        var id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter your FirstName: ");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("Enter your LastName: ");
                        string lastName = Console.ReadLine();

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

                        Console.Write("Enter your user ID: ");

                        userId = int.Parse(Console.ReadLine());

                        checkId = false;

                        foreach (var userAccount in accounts.Where(userAccount => userAccount.UserId == userId))
                        {
                            checkId = true;

                            Console.Write("Enter the Account Type to check you balance (C/S): ");

                            var accounttType = Convert.ToChar(Console.ReadLine().ToUpper());

                            var account = userAccount;

                            AccountOperations.CheckBalance(ref account, accounttType);
                        }

                        if (checkId == false)
                        {
                            Console.WriteLine(" No user Account exists for this user. Please setup your account!");
                        }

                        break;

                    case "3":

                        Console.Write("Enter your user ID: ");

                        userId = int.Parse(Console.ReadLine());

                        checkId = false;

                        foreach (var userAccount in accounts.Where(userAccount => userAccount.UserId == userId))
                        {
                            checkId = true;

                            Console.Write("Enter the Account Type to deposit (C/S): ");

                            var accounttType = Convert.ToChar(Console.ReadLine().ToUpper());

                            Console.Write("Enter the amount to be deposited : ");

                            var amount = decimal.Parse(Console.ReadLine());

                            var account = userAccount;

                            AccountOperations.DepositToYourAccount(ref account, amount, accounttType);
                        }

                        if (checkId == false)
                        {
                            Console.WriteLine(" No user Account exists for this user. Please setup your account!");
                        }

                        Console.WriteLine();

                        break;

                    case "4":
                        Console.Write("Enter your user ID: ");
                        var userID = int.Parse(Console.ReadLine());
                        bool checkUId = false;

                        foreach (var userAccount in accounts.Where(userAccount => userAccount.UserId == userID))
                        {
                            checkUId = true;
                            Console.Write("Enter the Account Type to withdraw (C/S): ");
                            var accountsType = Convert.ToChar(Console.ReadLine().ToUpper());

                            Console.Write("Enter the amount to be withdrawn : ");

                            var amount = decimal.Parse(Console.ReadLine());
                            var account = userAccount;
                            AccountOperations.WithdrawBalance(ref account, amount, accountsType);
                        }

                        if (checkUId == false)
                        {
                            Console.WriteLine("No such User id exists.");
                        }

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
