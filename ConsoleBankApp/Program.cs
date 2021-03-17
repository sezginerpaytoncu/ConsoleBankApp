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

            DatabaseOperations dbo = new DatabaseOperations();
            List<BankAccount> accountList = dbo.ReadFromFile();
            Console.WriteLine(" Name \t\tSurname   \tPassword  \tBalance");
            Console.WriteLine(" ======================================================");
            foreach (var item in accountList)
            {
                Console.WriteLine(String.Format(" {0,-15} {1,-15} {2,-15} {3,-15}", item.name, item.surname, item.password, item.balance));
            }
            

            Console.WriteLine(accountList[0].name);
            Console.ReadLine();

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
                    BankAccount account = new BankAccount(a, b, c);
                    DatabaseOperations.SaveAccount(a, b, c);




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
                    Console.WriteLine(" Yanlis Giris Yaptiniz.\n");
                    Console.WriteLine(" Lutfen Tekrar Deneyiniz.\n");
                    Console.WriteLine(" Lutfen Bekleyiniz...");
                    Console.WriteLine(" \n");
                    continue; //Continue to username & password control loop
                }
                else
                {
                    Console.WriteLine("\n Kullanici adi ve sifreniz dogrulanmaktadir...");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("\n Kullanici adi ve sifresi dogrulandi...\n");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break; //for döngüsünden çıkış sağlanmaktadır.
                }
            }








            char cevap2 = 'a';

            while (verification == true && selection3 != 1)
            {



                do
                {
                    //Console.WriteLine("Sayin %s %s, Sezgin Bank\'a Hos Geldiniz...\n\n", ad, soyad);
                    //printf("\n%s %s %d", ad, soyad, bakiye);
                    Console.WriteLine(" ISLEM MENUSU\n");
                    Console.WriteLine(" ============\n\n");
                    Console.WriteLine(" 1-Hesap Bakiyesi Goruntuleme\n");
                    Console.WriteLine(" 2-Hesaba Para Yatirma\n");
                    Console.WriteLine(" 3-Hesaptan Para Cekme\n");
                    Console.WriteLine(" 4-Para Gonderme\n");
                    Console.WriteLine(" 5-Cikis\n");
                    Console.WriteLine(" Luften Rakam Girerek Yapacaginiz Islemi Seciniz (1/2/3/4/5): ");
                    selection4 = Convert.ToByte(Console.ReadKey().Key);
                    Console.WriteLine("\n");
                    switch (selection4)
                    {
                        case 1: //Hesap bakiyesi görüntüleme.
                                //system("CLS");
                            Console.WriteLine("\n Hesap Bakiyesi Goruntuleme");
                            Console.WriteLine("\n --------------------------");
                            //Console.WriteLine("\n\n Hesabinizda Bulunan Para: %d TL \n", hesap[hesapNo].bakiye);
                            Console.WriteLine("\n\n");
                            break;

                        case 2: //Hesaba para yatırma.
                                //system("CLS");
                            Console.WriteLine("\n Hesaba Para Yatirma");
                            Console.WriteLine("\n ===================");
                            Console.WriteLine("\n\n Hesabiniza Yatacak Para Tutarini Giriniz:");
                            //Console.WriteLine("%d", &yatanPara);
                            //hesap[hesapNo].bakiye += yatanPara;
                            //*bakiye += yatanPara;
                            //VeritabaniGuncelle(hesap);
                            //Console.WriteLine(" Hesabiniza Yatan Para: %d TL \n\n", yatanPara);
                            //Console.WriteLine(" Hesabinizda Bulunan Para: %d TL \n", hesap[hesapNo].bakiye);
                            Console.WriteLine("\n\n");
                            break;

                        case 3: //Hesaptan para çekme.
                            /*while (true)
							{
								//system("CLS");
								Console.WriteLine("\n Hesaptan Para Cekme");
								Console.WriteLine("\n ===================");
								Console.WriteLine("\n\n Hesabinizdan Cekilecek Para Tutarini Giriniz:");
								//scanf("%d", &cekilenPara);
								if (cekilenPara <= hesap[hesapNo].bakiye)
								{
									//hesap[hesapNo].bakiye -= cekilenPara;
									//VeritabaniGuncelle(hesap);
									Console.WriteLine(" Hesabinizdan Cekilen Para: %d TL \n\n", cekilenPara);
									Console.WriteLine(" Hesabinizda Kalan Para: %d TL \n", hesap[hesapNo].bakiye);
									break;
								}

								else
								{
									Console.WriteLine("\n Bakiyeniz Yetersiz...\n\n");
									Console.WriteLine(" Hesabinizdan Cekilecek Para Tutarini Tekrar Giriniz.\n\n");
									//Sleep(2000);
									continue;
								}
							}*/
                            Console.WriteLine("\n\n");
                            break;

                        case 4: //Para gönderme.
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("\n Para Gonderme");
                                Console.WriteLine("\n =============");
                                Console.WriteLine("\n\n Hesabinizdan Gonderilecek Para Tutarini Giriniz:");
                                //scanf("%d", &gonderilenPara);
                                /*if (hesap[hesapNo].bakiye >= gonderilenPara)
								{
									hesap[hesapNo].bakiye -= gonderilenPara;
									VeritabaniGuncelle(hesap);
									Console.WriteLine(" Hesabinizdan Gonderilen Para Tutari: %d TL \n\n", gonderilenPara);
									Console.WriteLine(" Hesabinizda Kalan Para: %d TL \n", hesap[hesapNo].bakiye);
									break;
								}
								else
								{
									Console.WriteLine("\n");
									Console.WriteLine(" Bakiyeniz Yetersiz.\n\n");
									Console.WriteLine(" Hesabinizdan Gonderilecek Para Tutarini Tekrar Giriniz.\n");
									Sleep(2000);
									continue;
								}*/

                            }
                            Console.WriteLine("\n\n");
                            break;

                        case 5: //Banka sisteminden çıkış yapma.
                            Console.Clear();
                            Console.WriteLine("\n");
                            Console.WriteLine("Cikis yapiliyor...\n\n");
                            //cevap2 = 'H';  //Başka işlem yapmak istiyor musun? 'H': Hayır
                            //goto cikis;  //Kullanıcı direkt olarak çıkışa yönlendirilir. (NOT: goto kullanımı tavsiye edilmez. Bunun yerine döngüler kullanılabilir.)
                            break;

                        default: //Kullanıcının 1-2-3-4-5 dışında bir seçenek girmesi halide default yapısı çalışır.
                            Console.Clear();
                            Console.WriteLine("\n Boyle Bir Islem Secenegi Yoktur.\n");
                            Console.WriteLine("\n");
                            break;
                    }

                    if (selection4 == 5) //döngüden, yani banka otomasyonundan çıkmak için kurulmuştur.
                        break;


                    Console.WriteLine(" Do you want to continue? ( (Y)es - (N)o )");
                    cevap2 = Convert.ToChar(Console.ReadKey().KeyChar);
                    Console.Clear();

                } while (cevap2 == 'Y' || cevap2 == 'y'); // 'E' veya 'e' olması halinde menü ekrana gelecektir.

                if (cevap2 == 'N' || cevap2 == 'n') //'H' veya 'h' olması halinde döngüden çıkılacak ve çıkış işlemi gerçekleşecektir.
                    break;
                else
                {
                    Console.WriteLine(" You've entered an invalid value\n Returning to the menu");
                    continue;
                }

            }

        }


        static void Main(string[] args)
        {
            (new Program()).Run();




        }
    }
}
