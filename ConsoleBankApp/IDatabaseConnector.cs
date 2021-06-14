using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp
{
    interface IDatabaseConnector
    {
        void AddAccount(BankAccount account);
        void UpdateAccounts(List<BankAccount> lst);
        List<BankAccount> ReadAccounts();
        bool LoginCheck(string _name, string _surname, string _password, ref int _accountNumber);
    }
}
