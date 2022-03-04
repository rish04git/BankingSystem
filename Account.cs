using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem
{
    public class Account
    {
        public Account()
        {
            Accounts = new List<Customer>();
        }

        public List<Customer> Accounts { get; set; }
    }
}
