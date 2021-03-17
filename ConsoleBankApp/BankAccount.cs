using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleBankApp
{
    public class BankAccount
    {
        //public float balance;
        //public string name, surname, password;
        public int accountNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public decimal balance { get; set; }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

        }
        public void MakeRemittance()
        {

        }

        //constructor
        public BankAccount(int accountNumber, string name, string surname, string password, decimal initialBalance=0)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.balance = initialBalance;
        }


    }
}
