using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleBankApp
{
    class Program
    {
        public void Run()
        {
            byte accountNumber = 0, selection, selection2, selection3 = 0, selection4;
            int adminPassword = 123123, enteredAdminPassword;
            bool verification = false; //used for user login
            decimal depositAmount, withdrawalAmount;
            char answer = 'a'; //Declared for transaction menu, for Continue=(Y)ES or (N)O

            DatabaseOperations dbo = new DatabaseOperations();
            List<BankAccount> accountList = dbo.Read();

            while (true) //Main Menu
            {
                Console.Clear();
                Console.WriteLine(" ==============================================\n ================SEZGIN BANK===================\n =====Welcome to the Bank Account Program!=====\n ==============================================\n");
                Console.WriteLine(" 1.Login\n 2.Create new account\n 3.Admin account login\n 4.Exit\n");
                selection = Convert.ToByte(Console.ReadLine());

                if (selection == 1)
                    break;

                else if (selection == 2)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    int accountNumberInDatabase;
                    string createName, createSurname, createPassword;
                    Console.WriteLine(" ==================\n Create new account\n ==================\n");
                    Console.WriteLine(" Please enter your name:");
                    createName = Console.ReadLine();
                    Console.WriteLine("\n Please enter your surname:");
                    createSurname = Console.ReadLine();
                    Console.WriteLine("\n Please set a password for your account:");
                    createPassword = Console.ReadLine();
                    //Creating a new account and writing it to txt file
                    accountNumberInDatabase = accountList.Count;
                    BankAccount account = new BankAccount(accountNumberInDatabase+1, createName, createSurname, createPassword);
                    accountList.Add(account);
                    dbo.Write(accountList);
                    Console.WriteLine(" New account created! Press any key to continue...");
                    Console.ReadKey();
                }

                else if (selection == 3)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine(" Please enter password for admin login:");
                    enteredAdminPassword = Convert.ToInt32(Console.ReadLine());

                    if (enteredAdminPassword == adminPassword)
                    {
                        Console.WriteLine("\n The admin password is correct...");
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine(" =============\n Admin Account\n =============\n");
                        Console.WriteLine(" 1.All accounts\n 2.Exit\n");
                        selection2 = Convert.ToByte(Console.ReadLine());
                        switch (selection2)
                        {
                            case 1:
                                Console.Clear();
                                dbo.ShowAllAccounts(accountList);
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("\n You have entered an incorrect value.Please try again...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n You have entered an incorrect value.Please try again...");
                        Console.Clear();
                    }

                }

                else if (selection == 4)
                {
                    selection3 = 1;
                    break;
                }

                else
                    Console.WriteLine(" You have entered an incorrect value.Please try again...");
            }

            while (selection3 != 1) //Username&Password control for login
            {
                string enteredName, enteredSurname, enteredPassword;
                accountNumber = 0;

                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(" User Login\n ==========");
                Console.WriteLine("\n Please enter your name:");
                enteredName = Console.ReadLine();
                Console.WriteLine("\n Please enter your surname:");
                enteredSurname = Console.ReadLine();
                Console.WriteLine("\n Please enter your password:");
                enteredPassword = Console.ReadLine();

                verification = dbo.LoginCheck(enteredName, enteredSurname, enteredPassword, ref accountNumber);
                if (verification == true)
                    break;
            }

            while (verification == true && selection3 != 1) //Transaction Menu
            {             
                BankAccount currentAccount = accountList[accountNumber];

                do
                {
                    Console.Clear();
                    Console.WriteLine(" Welcome, {0} {1}\n Account number:{2}", currentAccount.name, currentAccount.surname, currentAccount.accountNumber);
                    Console.WriteLine(" ============\n TRANSACTION MENU\n ============\n\n");
                    Console.WriteLine(" 1-View account balance\n 2-Deposit\n 3-Withdrawal\n 4-Remittance/Transfer\n 5-Exit\n");
                    Console.WriteLine(" Please select transaction by entering number (1/2/3/4/5): ");
                    selection4 = Convert.ToByte(Console.ReadLine());
                    switch (selection4)
                    {
                        case 1: //Displaying account's balance
                            Console.Clear();
                            Console.WriteLine(" View account balance\n  ====================");
                            Console.WriteLine(" Your current balance: {0}$ \n\n", currentAccount.balance);
                            break;

                        case 2: //Deposit to account
                            Console.Clear();
                            Console.WriteLine("\n Deposit to your account\n =======================\n");
                            Console.WriteLine("\n Please enter the amount you want to deposit into your account:");
                            depositAmount = Convert.ToDecimal(Console.ReadLine());
                            currentAccount = currentAccount.MakeDeposit(currentAccount, depositAmount);
                            dbo.Write(accountList);
                            break;

                        case 3: //Withdrawal
                            Console.Clear();
                            Console.WriteLine("\n Withdrawal\n ==========\n");
                            Console.WriteLine("\n Please enter the amount you want to withdraw from your account:");
                            withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                            currentAccount = currentAccount.MakeWithdrawal(currentAccount, withdrawalAmount);
                            dbo.Write(accountList);
                            break;

                        case 4: //Money Transfer-Remittance
                            while (true)
                            {
                                int receiverAccountNumber;
                                decimal remittanceAmount;
                                Console.Clear();
                                Console.WriteLine("\n Remittance\n ==========");
                                Console.Write("\n\n Please enter receiver's account number: ");
                                receiverAccountNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                                if(receiverAccountNumber<0 || receiverAccountNumber >= accountList.Count || receiverAccountNumber==accountNumber)
                                {
                                    Console.WriteLine(" You've entered an invalid account number...");
                                    break;
                                }
                                Console.Write("\n\n Please enter the amount you want to transfer: ");
                                remittanceAmount = Convert.ToInt32(Console.ReadLine());
                                if (remittanceAmount < 0)
                                {
                                    Console.WriteLine(" You've entered an invalid value...");
                                    break;
                                }
                                else if (currentAccount.balance >= remittanceAmount)
								{
                                    currentAccount.balance -= remittanceAmount;
                                    accountList[receiverAccountNumber].balance += remittanceAmount;
                                    dbo.Write(accountList);
									Console.WriteLine(" You have transferred {0}$ to {1} {2}'s account.\n\n", remittanceAmount, currentAccount.name, accountList[receiverAccountNumber].surname);
									Console.WriteLine(" Your current balance: {0}$ \n", currentAccount.balance);
									break;
								}
								else
								{
									Console.WriteLine("\n");
									Console.WriteLine(" Insufficient balance...\n\n");
									System.Threading.Thread.Sleep(1500);
									continue;
								}
                            }
                            Console.WriteLine("\n\n");
                            break;

                        case 5: //Exit from bank app.
                            Console.Clear();
                            Console.WriteLine("\n Exiting...\n\n");
                            answer = 'N';  //Do you want to continue=> 'N': NO
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n You've entered an invalid value...\n\n");
                            break;
                    }

                    if (selection4 == 5) //Exit from the transaction menu loop
                        break;

                    Console.WriteLine(" Do you want to continue? ( (Y)es - (N)o )");
                    answer = Convert.ToChar(Console.ReadKey().KeyChar);

                } while (answer == 'Y' || answer == 'y');

                if (answer == 'N' || answer == 'n')
                    break;
                else
                {
                    Console.WriteLine(" You've entered an invalid value\n Returning to the menu");
                    System.Threading.Thread.Sleep(1500);
                    continue;
                }

            }
            Console.Clear();
            Console.WriteLine("\n Exit\n =====");
            Console.WriteLine("\n Exiting from the Bank Application...");
            Console.WriteLine("\n Thank you for using Sezgin Bank! :)");
            System.Threading.Thread.Sleep(2500);
        }

        static void Main(string[] args)
        {
            (new Program()).Run();




        }
    }
}
