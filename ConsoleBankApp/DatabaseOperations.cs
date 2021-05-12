using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleBankApp
{
    public class DatabaseOperations
    {

        public void Write(List<BankAccount> lst)
        {
            StreamWriter sw = new StreamWriter("AccountDatabase.txt");
            foreach (var item in lst)
            {
                sw.WriteLine(String.Format("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15}", item.accountNumber, item.name, item.surname, item.password, item.balance));
            }
            sw.Close();
        }

        public List<BankAccount> Read()
        {
            if (File.Exists("AccountDatabase.txt") == false)
            {              
                FileStream fs = new FileStream("AccountDatabase.txt", FileMode.Create);
                fs.Close();
            }

            List<string> lines = new List<string>();
            List<BankAccount> baList = new List<BankAccount>();

            lines = File.ReadAllLines("AccountDatabase.txt").ToList();
            foreach (string line in lines)
            {
                string[] items = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                BankAccount ba = new BankAccount(Convert.ToInt32(items[0]), items[1], items[2], items[3], Convert.ToDecimal(items[4]));
                baList.Add(ba);
            }
            return baList;
        }

        public bool LoginCheck(string _name, string _surname, string _password, ref byte _accountNumber)
        {
            Console.WriteLine("\n Checking username and password...\n");
            System.Threading.Thread.Sleep(1000);
            bool flag = false;
            FileStream fs = new FileStream("AccountDatabase.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] components = new string[4];
                components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (components[1] == _name && components[2] == _surname && components[3] == _password)
                {
                    flag = true;
                    break;
                }
                _accountNumber++;
            }
            fs.Close();
            if (flag == true)
            {
                Console.WriteLine("\n Username and password verified!\n");
                System.Threading.Thread.Sleep(1300);
                return true;
            }
            else
            {
                Console.WriteLine(" Wrong username or password!\n\n Please try again...\n");
                System.Threading.Thread.Sleep(1000);
                return false;
            }
        }
        public void ShowAllAccounts(List<BankAccount> accountList)
        {
            Console.WriteLine("\n AccountNo  Name            Surname         Password        Balance");
            Console.WriteLine(" ==================================================================");
            foreach (var item in accountList)
            {
                Console.WriteLine(String.Format(" {0,-10} {1,-15} {2,-15} {3,-15} {4,-15}", item.accountNumber, item.name, item.surname, item.password, item.balance));
            }
            Console.WriteLine("\n Press any key to exit...");
            Console.ReadKey();
        }

    }

}

