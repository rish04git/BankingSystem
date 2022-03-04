using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem
{
    public class User : AccountDetails
    {
        public int UserId { get; set; }
        public List<AccountDetails> UserAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long? PhoneNumber { get; set; }

        public User(int userId, string firstName, string lastName, string email, long? phoneNumber)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.UserAccount = new List<AccountDetails>();
        }
    }

    public class AccountDetails
    {
        public char AccountType { get; set; }
        public int AccountNo { get; set; }
        public decimal GetAccountBalance { get; set; }
    }
}
