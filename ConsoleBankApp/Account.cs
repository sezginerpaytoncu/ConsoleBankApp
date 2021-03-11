using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleBankApp
{
    class Account
    {
        private float balance;
        private string name, surname, password;

        

        /*
        public float balance() { get; set; }
        public string name() { get; set; }
        public string surname() { get; set; }
        public string password() { get; set; }
        */
        //constructor
        public Account()
        {
        
        }

        // Read accounts from the FILE


        // Write&Save account to the FILE
        public void SaveAccount(string _name, string _surname, string _password, float _balance=0)
        {
            StreamWriter sw = new StreamWriter("AccountDatabase.txt");
            sw.WriteLine(_name + "\t\t" + _surname + "\t\t" + _password + "\t\t" + _balance);
            sw.Flush();
            sw.Close();
        }

        // Show all the accounts in the FILE

        // Update FILE???

    }
}
