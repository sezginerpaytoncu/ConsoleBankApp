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
        public int accountNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public decimal balance { get; set; }
        //constructor
        public BankAccount(int accountNumber, string name, string surname, string password, decimal initialBalance = 0)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.balance = initialBalance;
        }
        public BankAccount MakeDeposit(BankAccount account, decimal amount)
        {
            if (amount <=0)
            {
                Console.WriteLine(" You've entered an invalid value\n\n");
                return account;
            }
            Console.WriteLine("\n Deposit amount: {0}$", amount);
            System.Threading.Thread.Sleep(1000);
            account.balance += amount;
            Console.WriteLine("\n Your current balance: {0}$\n\n", account.balance);
            return account;
        }
        public BankAccount MakeWithdrawal(BankAccount account, decimal amount)
        {
            if (amount <= account.balance && amount>0)
            {
                account.balance -= amount;
                Console.WriteLine(" Withdrawal amount: {0}$TL \n\n", amount);
                Console.WriteLine(" Your current balance: {0}$\n\n", account.balance);
                return account;
            }
            else if (amount <= 0)
            {
                Console.WriteLine(" You've entered an invalid value...\n\n");
            }
            else
            {
                Console.WriteLine(" Insufficient balance...\n\n");
            }
            return account;
        }
      

    }
}
