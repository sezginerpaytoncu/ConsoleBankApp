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
        /*
        static void ReadAccounts()
        {
            FileStream fs = new FileStream("AccountDatabase.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int i = 0;
            while (sr.ReadLine() != null)
            {
                
                Account[i].Name = sr.ReadLine();
                Account[i].Surname = sr.ReadLine();
                Account[i].Password = sr.ReadLine();
                Account[i].Balance = Convert.ToDecimal(sr.ReadLine());
                i++;
            }
        }*/
        public static void SaveAccount(string _name, string _surname, string _password, float _balance = 0)
            {
                StreamWriter sw = new StreamWriter("AccountDatabase.txt", append: true);
                sw.WriteLine(String.Format("{0,-15} {1,-15} {2,-10} {3,-15}", _name, _surname, _password, _balance));
                sw.Flush();
                sw.Close();
            }
        static void ShowAccounts()
        {

        }



        public void WriteToFile(List<BankAccount> lst)
        {
            //lst file'a yazılacak
        }

        public List<BankAccount> ReadFromFile()
        {
            //FileStream fs = new FileStream("AccountDatabase.txt", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs);
            List<string> lines = new List<string>();
            List<BankAccount> baList = new List<BankAccount>();

            lines = File.ReadAllLines("AccountDatabase.txt").ToList();
            foreach (string line in lines)
            {
                //string[] items = line.Split(' ');
                string[] items = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                BankAccount ba = new BankAccount(items[0], items[1], items[2], Convert.ToDecimal(items[3]));
                baList.Add(ba);
            }


            return baList;
        }



        public static bool LoginCheck(string _name, string _surname, string _password, ref byte _accountNumber)
        {
            bool flag = false;
            FileStream fs = new FileStream("AccountDatabase.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] components = new string[4];
                components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(components[0] + " " + components[1] + " " + components[2] + " " + components[3]);
                Console.ReadKey();
                if (components[0] == _name && components[1] == _surname && components[2] == _password)
                {
                    Console.WriteLine("User's name, surname and password verified");
                    flag = true;
                    break;
                }
                _accountNumber++;
            }
            fs.Close();
            if (flag == true)
                return true;
            else
                return false;
        }


    }

}

