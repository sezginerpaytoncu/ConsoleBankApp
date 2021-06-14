using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ConsoleBankApp
{
    class SqlDatabaseOperations:IDatabaseConnector
    {
        public void AddAccount(BankAccount acc)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1DE2ISN\;Initial Catalog=Accounts;Integrated Security=True");
            con.Open();
            SqlCommand insertCmd = new SqlCommand("INSERT INTO AccountInfo (Name, Surname, Password, Balance) VALUES (@Name, @Surname, @Password, @Balance)", con);
            insertCmd.Parameters.Add(new SqlParameter("Name", acc.name));
            insertCmd.Parameters.Add(new SqlParameter("Surname", acc.surname));
            insertCmd.Parameters.Add(new SqlParameter("Password", acc.password));
            insertCmd.Parameters.Add(new SqlParameter("Balance", acc.balance));
            insertCmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateAccounts(List<BankAccount> lst)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1DE2ISN\;Initial Catalog=Accounts;Integrated Security=True");
            con.Open();
            foreach (var item in lst)
            {
                SqlCommand insertCmd = new SqlCommand("UPDATE AccountInfo SET Name=@Name, Surname=@Surname, Password=@Password, Balance=@Balance WHERE Name=@Name AND Surname=@Surname", con);
                insertCmd.Parameters.Add(new SqlParameter("Name", item.name));
                insertCmd.Parameters.Add(new SqlParameter("Surname", item.surname));
                insertCmd.Parameters.Add(new SqlParameter("Password", item.password));
                insertCmd.Parameters.Add(new SqlParameter("Balance", item.balance));
                insertCmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public List<BankAccount> ReadAccounts()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1DE2ISN\;Initial Catalog=Accounts;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from AccountInfo", con);
            con.Open();
            Console.WriteLine("Connection Opened");
            SqlDataReader dr = cmd.ExecuteReader();
            List<BankAccount> baList = new List<BankAccount>();

            int i = 0;
            while (dr.Read())
            {
                BankAccount ba = new BankAccount(Convert.ToInt32(dr["AccountNumber"]), dr["Name"].ToString(), dr["Surname"].ToString(), dr["Password"].ToString(), Convert.ToDecimal(dr["Balance"]));
                baList.Add(ba);
                i++;
            }
            dr.Close();
            return baList;
        }

        public bool LoginCheck(string _name, string _surname, string _password, ref int _accountNumber)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1DE2ISN\;Initial Catalog=Accounts;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from AccountInfo", con);
            con.Open();
            Console.WriteLine("Connection Opened");
            SqlDataReader dr = cmd.ExecuteReader();
            bool flag=false;
            while (dr.Read())
            {
                if (_name == dr["Name"].ToString() && _surname == dr["Surname"].ToString() && _password == dr["Password"].ToString()) 
                {
                    con.Close();
                    flag = true;
                    break;
                }
                _accountNumber++;
            }
            if (flag == true)
            {
                con.Close();
                Console.WriteLine("\n Username and password verified!\n");
                System.Threading.Thread.Sleep(1300);
                return true;
            }
            else
            {
                con.Close();
                Console.WriteLine(" Wrong username or password!\n\n Please try again...\n");
                System.Threading.Thread.Sleep(1000);
                return false;
            }
        }
    }
}
