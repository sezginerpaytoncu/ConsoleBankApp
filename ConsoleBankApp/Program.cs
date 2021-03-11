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
        static void Main(string[] args)
        {
            byte selection, selection2, selection3=0;
			int adminPassword=123123, enteredAdminPassword;

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
					string a, b, c;
					Console.WriteLine(" ==================\n Create new account\n ==================\n");
					Console.WriteLine(" Please enter your name:");
					a = Console.ReadLine();
					Console.WriteLine("\n Please enter your surname:");
					b = Console.ReadLine();
					Console.WriteLine("\n Please set a password for your account:");
					c = Console.ReadLine();
					//Hesap ekleme
					Account account = new Account();
					account.SaveAccount(a, b, c);


					//Kayıt başarılı
					Console.ReadLine();
				}

				else if (selection == 3)
				{
					System.Threading.Thread.Sleep(1000);
					Console.Clear();
					Console.WriteLine(" Please enter password for admin login:");
					enteredAdminPassword = Convert.ToInt32(Console.ReadLine());

					if (enteredAdminPassword == adminPassword)
					{
						Console.WriteLine(" ============\n Admin Hesabi\n ============\n");
						Console.WriteLine(" 1.All accounts\n 2.Exit\n");
						selection2 = Convert.ToByte(Console.ReadLine());
						switch (selection2)
						{
							case 1:
								//dosyadan bilgileri yazdır
								//HesapGoster(hesap);
								Console.WriteLine("\n Press any key to exit...");
								Console.ReadLine();
								Console.Clear();
								break;
							case 2:
								break;
							default:
								Console.WriteLine("\nHatali giris yaptiniz. Ana menuye donmek icin herhangi bir tusa basiniz...");
								Console.ReadLine();
								Console.Clear();
								break;
						}
					}
					else
					{
						Console.WriteLine("\nHatali giris yaptiniz. Ana menuye donmek icin herhangi bir tusa basiniz...");
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
					Console.WriteLine("You have entered an incorrect value.Please try again...");

			}

            while (selection3 != 1)//Username&Password control for logging in...
            {
				string enteredName, enteredSurname, enteredPassword;
				Boolean flag;

				System.Threading.Thread.Sleep(1500);
				Console.Clear();
				Console.WriteLine(" User Login\n ==========");
				Console.WriteLine("\n Please enter your name:");
				enteredName = Console.ReadLine();
				Console.WriteLine("\n Please enter your surname:");
				enteredSurname = Console.ReadLine();
				Console.WriteLine("\n Please enter your password:");
				enteredPassword = Console.ReadLine();

				Console.WriteLine("{0} {1} {2}", enteredName, enteredSurname, enteredPassword);


				/*
				for (int i = 0; i < 50; i++)
				{ //Kullanıcın Adı, Soyadı ve Şifresi sorgulanıyor...

					char* ad = hesap[j].ad;
					char* soyad = hesap[j].soyad;
					char* sifre = hesap[j].sifre;


					getch();
					fflush(stdin);

					int a = strcmp(adkontrol, ad);
					int b = strcmp(soyadkontrol, soyad);
					int c = strcmp(sifrekontrol, sifre);




					if (a == 0 && b == 0 && c == 0)
					{
						kontrol = 1;
						hesapNo = j;
						printf("Hesap no: %d, Hesap no'ya atanan J degeri: %d", hesapNo, j);
						getch();
						fflush(stdin);
						break;
					}
					else
						continue;
				}


				if (kontrol == 0) //Kullanıcının girmiş olduğu kullanıcı adıyla, sistemde kayitli kullanıcı adının uyuşmaması halinde if komutu çalışır. 
				{
					printf("\n Yanlis Giris Yaptiniz.\n");
					printf(" Lutfen Tekrar Deneyiniz.\n");
					printf("\n Lutfen Bekleyiniz...");
					printf("\n");
					continue; //Tekrar kullanici girisi -for- döngüsüne dön
				}

				else //Kullanıcının girmiş olduğu kullanıcı adıyla, sistemde kayitli kullanıcı adının uyuşması halinde else komutu çalışır.
				{
					printf("\n Kullanici adi ve sifreniz dogrulanmaktadir...");
					Sleep(1500);
					system("CLS");
					printf("\n Kullanici adi ve sifresi dogrulandi...\n");
					Sleep(1500);
					system("CLS");
					break; //for döngüsünden çıkış sağlanmaktadır.
				}
			*/

			}



        }
    }
}
