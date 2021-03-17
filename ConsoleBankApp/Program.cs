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
            List<BankAccount> accountList = dbo.ReadFromFile();

            

            //Console.WriteLine(accountList[0].name);
            //Console.ReadLine();

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
                    int a;
                    string b, c, d;
                    Console.WriteLine(" ==================\n Create new account\n ==================\n");
                    Console.WriteLine(" Please enter your name:");
                    b = Console.ReadLine();
                    Console.WriteLine("\n Please enter your surname:");
                    c = Console.ReadLine();
                    Console.WriteLine("\n Please set a password for your account:");
                    d = Console.ReadLine();
                    //Creating new account and writing to txt file
                    a = accountList.Count;
                    BankAccount account = new BankAccount(a+1, b, c, d);
                    accountList.Add(account);
                    dbo.WriteToFile(accountList);
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
                        Console.WriteLine("The admin password is correct...");
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine(" ============\n Admin Hesabi\n ============\n");
                        Console.WriteLine(" 1.All accounts\n 2.Exit\n");
                        selection2 = Convert.ToByte(Console.ReadLine());
                        switch (selection2)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("\n AccountNo  Name            Surname         Password        Balance");
                                Console.WriteLine(" ==================================================================");
                                foreach (var item in accountList)
                                {
                                    Console.WriteLine(String.Format(" {0,-10} {1,-15} {2,-15} {3,-15} {4,-15}", item.accountNumber, item.name, item.surname, item.password, item.balance));
                                }
                                Console.WriteLine("\n Press any key to exit...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("\n You have entered an incorrect value.Please try again...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n You have entered an incorrect value.Please try again...");
                        Console.WriteLine();
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

            while (selection3 != 1)//Username&Password control for logging in...
            {
                string enteredName, enteredSurname, enteredPassword;

                accountNumber = 0;

                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine(" User Login\n ==========");
                Console.WriteLine("\n Please enter your name:");
                enteredName = Console.ReadLine();
                Console.WriteLine("\n Please enter your surname:");
                enteredSurname = Console.ReadLine();
                Console.WriteLine("\n Please enter your password:");
                enteredPassword = Console.ReadLine();

                verification = DatabaseOperations.LoginCheck(enteredName, enteredSurname, enteredPassword, ref accountNumber);

                if (verification == false)
                {
                    Console.WriteLine("\n Checking username and password...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine(" Wrong username or password!\n");
                    Console.WriteLine(" Please try again...\n");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine(" \n");
                    continue; //Continue to username & password control loop
                }
                else
                {
                    Console.WriteLine("\n Checking username and password...");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("\n Username and password verified!\n");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break; //exit from the login screen and continue with transaction menu
                }
            }

            while (verification == true && selection3 != 1)
            {
                for(int j=0; j<accountList.Count;j++)
                {
                    Console.WriteLine(accountList[j].name+ accountList[j].surname + accountList[j].accountNumber + accountList[j].accountNumber);
                }


                do
                {
                    Console.Clear();
                    Console.WriteLine(" Welcome, {0} {1}\n Account number:{2}", accountList[accountNumber].name, accountList[accountNumber].surname, accountList[accountNumber].accountNumber);
                    Console.WriteLine(" ============\n TRANSACTION MENU\n ============\n\n");
                    Console.WriteLine(" 1-View account balance\n 2-Deposit\n 3-Withdrawal\n 4-Remittance/Transfer\n 5-Exit\n");
                    Console.WriteLine(" Please select transaction by entering number (1/2/3/4/5): ");
                    selection4 = Convert.ToByte(Console.ReadLine());
                    switch (selection4)
                    {
                        case 1: //Displaying account's balance
                            Console.Clear();
                            Console.WriteLine(" View account balance");
                            Console.WriteLine(" ====================");
                            Console.WriteLine("\n\n Your current balance: {0}$ \n", accountList[accountNumber].balance);
                            Console.WriteLine("\n\n");
                            break;

                        case 2: //Deposit to account
                            Console.Clear();
                            Console.WriteLine("\n Deposit to your account");
                            Console.WriteLine("\n =======================");
                            Console.WriteLine("\n\n Please enter the amount you want to deposit into your account:");
                            depositAmount = Convert.ToDecimal(Console.ReadLine());
                            if (depositAmount <= 0)
                            {
                                Console.WriteLine(" You've entered an invalid value");
                                break;
                            }
                            Console.WriteLine("\n Deposit amount: {0}$", depositAmount);
                            System.Threading.Thread.Sleep(1000);
                            accountList[accountNumber].balance += depositAmount;
                            dbo.WriteToFile(accountList);
                            Console.WriteLine("\n Your current balance: {0}$\n", accountList[accountNumber].balance);
                            break;

                        case 3: //Withdrawal
                            while (true)
							{
								Console.Clear();
								Console.WriteLine("\n Hesaptan Para Cekme");
								Console.WriteLine("\n ===================");
								Console.WriteLine("\n\n Hesabinizdan Cekilecek Para Tutarini Giriniz:");
                                withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                                //scanf("%d", &cekilenPara);
								if (withdrawalAmount <= accountList[accountNumber].balance)
								{
                                    accountList[accountNumber].balance -= withdrawalAmount;
                                    dbo.WriteToFile(accountList);
									Console.WriteLine(" Withdrawal amount: {0}$TL \n\n", withdrawalAmount);
									Console.WriteLine(" Your current balance: {0}$\n", accountList[accountNumber].balance);
									break;
								}
                                else if (withdrawalAmount <= 0)
                                {
                                    Console.WriteLine(" You've entered an invalid value...");
                                    break;
                                }
								else
								{
									Console.WriteLine("\n Insufficient balance...\n\n");
                                    System.Threading.Thread.Sleep(1000);
                                    continue;
								}
							}
                            Console.WriteLine("\n\n");
                            break;

                        case 4: //Money Transfer-Remittance
                            while (true)
                            {
                                int receiverAcountNumber;
                                decimal remittanceAmount;
                                Console.Clear();
                                Console.WriteLine("\n Remittance");
                                Console.WriteLine("\n ==========");
                                Console.Write("\n\n Please enter receiver's account number: ");
                                receiverAcountNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                                if(receiverAcountNumber<0 || receiverAcountNumber >= accountList.Count || receiverAcountNumber==accountNumber)
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

                                if (accountList[accountNumber].balance >= remittanceAmount)
								{
                                    accountList[accountNumber].balance -= remittanceAmount;
                                    accountList[receiverAcountNumber].balance += remittanceAmount;
                                    dbo.WriteToFile(accountList);
									Console.WriteLine(" You have transferred {0}$ to {1} {2}'s account.\n\n", remittanceAmount, accountList[receiverAcountNumber].name, accountList[receiverAcountNumber].surname);
									Console.WriteLine(" Your current balance: {0}$ \n", accountList[accountNumber].balance);
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
                            Console.WriteLine("\n");
                            Console.WriteLine(" Exiting...\n\n");
                            answer = 'N';  //Do you want to continue=> 'N': NO
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n You've entered an invalid value...\n");
                            Console.WriteLine("\n");
                            break;
                    }

                    if (selection4 == 5) //Exit from the transaction menu loop
                        break;


                    Console.WriteLine(" Do you want to continue? ( (Y)es - (N)o )");
                    answer = Convert.ToChar(Console.ReadKey().KeyChar);
                    Console.Clear();

                } while (answer == 'Y' || answer == 'y'); // 'E' veya 'e' olması halinde menü ekrana gelecektir.

                if (answer == 'N' || answer == 'n') //'H' veya 'h' olması halinde döngüden çıkılacak ve çıkış işlemi gerçekleşecektir.
                    break;
                else
                {
                    Console.WriteLine(" You've entered an invalid value\n Returning to the menu");
                    continue;
                }

            }
            Console.Clear();
            Console.WriteLine("\n Exit");
            Console.WriteLine("\n =====");
            Console.WriteLine("\n\n Exiting from the Bank Application...");
            Console.WriteLine("\n Thank you for using Sezgin Bank! :)");
            System.Threading.Thread.Sleep(3000);
        }


        static void Main(string[] args)
        {
            (new Program()).Run();




        }
    }
}
