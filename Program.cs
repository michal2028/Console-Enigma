using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ConsoleApp1
{
    class Program
    {
       

        static void RysujEnigne()
        {
            string[] MenuImage = new string[16]
            {
                "___________________________",
                "|_________________________|",
                "| |       ENIGMA        | |",
                "| |     CREATED BY      | |",
                "| |    MICHAL NOWAK     | |",
                "| |                     | |",
                "| |_____________________| |",
                "|                         |",
                "|  |R1|    |R2|    |R3|   |",
                "|   ^^      ^^      ^^    |",
                "| {   }   {   }   {   }   |",
                "| _______________________ |",
                "|   Q W E R T Z U I O     |",
                "|    S A D F G H J K      |",
                "|   P Y X C V B N M L     |",
                "|_________________________|"

            };

            foreach(string i in MenuImage)
            {
                Console.WriteLine(i);
            }
            
                
    
                        

        }

        static void RysujInstrukcje()
        {
            string[] MenuImage = new string[4]
            {
                "1. Maszyna pobierze od ciebie 3 znakowy klucz ktorym bedziesz w stanie \n" +
                " zaszyfrowac lub odszyfrowac wiadomosc.",
                "2. Klucz jak i wiadomosci okreslone sa scislymi regulami ich wprowadzania.",
                "3. Klucz jak i wiadomosc musza byc okreslone literami alfabetu polskiego bez \n" +
                " znakow specjlanych i znakow polskich - Zakres <A-Z> plus znak bialy ( spacja ).",
                "4. W przypadku wprowadzenia niepoprawnych wartosci klucza lub wiadomosci, maszyna \n" +
                " poprosi o ponowne ich wprowadzenie."
             

            };

            foreach (string i in MenuImage)
            {
                Console.WriteLine(i);
            }

        }
        static int LoadKey(string s_tekst, string Rotor)
        {
            int Key = 0;
            char TryKey ;
            
            bool CzyMiesciSie = true;
            while (CzyMiesciSie == true)
            {
                Console.WriteLine(s_tekst);
               if (char.TryParse(Console.ReadLine(), out TryKey) == true)
                {
                    TryKey = Char.ToUpper(TryKey);
                  
                    for(int x = 0; x <= Rotor.Length - 1; x++)
                    {
                        if(TryKey == Rotor[x])
                        {
                            CzyMiesciSie = false;
                            for (int i = 0; i <= Rotor.Length - 1; i++) // Przypisywanie numeru klucza dla rotoru 
                            {
                                if (TryKey == Rotor[i])
                                {
                                    Key = i;
                                }


                            }
                        }

                    }
                    

                    continue;
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy format klucza !");
                    continue;

                }


            }

            


            return Key;
        }

        static int EncriptKey(int one, int two, int three)
        {
            int Key = 0;
            Key = one + three;
            if(Key < 25)
            {
                return Key;
            }else
            {
                Key = Key - two;
                if(Key > 25)
                {
                    Key = Key - one;
                    if(Key < 0)
                    {
                        Key = Key * -1;
                    }
                }
                
                return Key;
            }
   
        }
        static int PodajLiczbe(string tekst, int Min, int Max)
        {

            int Sprawdz;

            while (true)
            {
                Console.WriteLine(tekst);

                if (int.TryParse(Console.ReadLine(), out Sprawdz) == true)
                {
                    if (Sprawdz < Min || Sprawdz > Max)
                    {
                        Console.WriteLine($"Niepoprawne dane, liczba nie miesci sie w przedziale {Min} <> {Max}");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy format danych");
                    continue;
                }
                return Sprawdz;
            }

        }

        static string WordsToEncript(string s_tekst, string Zakres)
        {
            string Zdanie_Ready = "";


            while (true)
            {
                string zdanie = "";
                int Licznik = 0;
                Console.WriteLine(s_tekst);
                zdanie = Console.ReadLine();
                zdanie = zdanie.ToUpperInvariant();
                for (int i = 0; i <= zdanie.Length - 1; i++)
                {

                    for (int x = 0; x <= Zakres.Length - 1; x++)
                    {
                        if (zdanie[i] == Zakres[x])
                        {

                            Licznik++;

                        }

                    }

                }
                if (Licznik == zdanie.Length)
                {
                   
                    Zdanie_Ready = zdanie;
                    break;


                }
                else
                {
                    Console.WriteLine("Wprowadzona wartosc nie nalezy do zakresu danych mozliwych do szyfrowania !");
                    continue;
                }

            }
            return Zdanie_Ready;
        }
        static string WordsToEncript2(string s_tekst, string Zakres)
        {
            string Zdanie_Ready = "";


            while (true)
            {
                string zdanie = s_tekst;
                int Licznik = 0;
                
                
                zdanie = zdanie.ToUpperInvariant();
                for (int i = 0; i <= zdanie.Length - 1; i++)
                {

                    for (int x = 0; x <= Zakres.Length - 1; x++)
                    {
                        if (zdanie[i] == Zakres[x])
                        {

                            Licznik++;

                        }

                    }

                }
                if (Licznik == zdanie.Length)
                {

                    Zdanie_Ready = zdanie;
                    break;


                }
                else
                {
                    Console.WriteLine("Wprowadzona wartosc nie nalezy do zakresu danych mozliwych do szyfrowania !");
                    continue;
                }

            }
            return Zdanie_Ready;
        }
        static string EncriptMachine( int Klucz,string Zdanie, string Rotor1, string Rotor2)
        {

            string ZdanieRotor1 = "";

            for (int i = 0; i <= Zdanie.Length - 1; i++)
            {
                int Rotor1_int = 0;



                for (int x = 0; x <= Rotor1.Length - 1; x++) //Wyszukiwanie numeru znaku w rotorze 1
                {

                    if (Zdanie[i] == Rotor1[x])
                    {
                        Rotor1_int = x + Klucz;

                        if (Rotor1_int > 25)
                        {
                            Rotor1_int = Rotor1_int - 25;


                        }

                    }
                }
                ZdanieRotor1 = ZdanieRotor1 + Rotor2[Rotor1_int]; // Koniec szyfrowania pierwszego rotoru




            }

            return ZdanieRotor1;


        }

       

        static string DecriptMachine(int Klucz ,string Zdanie_Decript, string Rotor1, string Rotor2)
        {

            string Zdanie_Ready = "";
            // mechanizm deszyfracji na podstawie klucza

            for (int i = 0; i <= Zdanie_Decript.Length - 1; i++)
            {
                int Z1 = 0;
                for (int x = 0; x <= Rotor2.Length - 1; x++)
                {

                    if (Zdanie_Decript[i] == Rotor2[x])
                    {

                        Z1 = x - Klucz;
                        if (Z1 < 0)
                        {
                            Z1 = Z1 + 25;
                        }
                        
                        Zdanie_Ready = Zdanie_Ready + Rotor1[Z1];
                    }
                    //Z     Z  Y Z   3
                    //SPAYPUSPVPRSHAP
                    //BAPRASBAMA BUPA 3
                }
            }
            return Zdanie_Ready;

        }


        static void MainApp()
        {
            string Rotor1 = "ABCDEFGH IJKYLMNOPWZRSTUVQX"; // W ->  + 11 znakow od znaku W czyli 23 + 11 = 34 - 26 = 8
            string Rotor2 = "NTZPSFBOKMWRCJDIVL AEYUXHGQ"; // 8 + 15 = 23 
            int[] Key_int = new int[3];
            int[] Key_int_Decript = new int[3];
            bool Gra = true;
            


            while (Gra)
            {


                RysujEnigne();
                Console.WriteLine("\n1. Zakoduj wiadomosc przy uzyciu klucza ");
                Console.WriteLine("2. Rozszyfruj wiadomosc przy uzyciu klucza ");
                Console.WriteLine("3. Instrukcja obslugi ");
                Console.WriteLine("4. Odczyt z pliku");
                Console.WriteLine("5. Wyjscie ");
               
                

             
                int Opcja = PodajLiczbe("\nWybierz opcje =", 1, 4);
                switch (Opcja)
                {
                    case 1:

                        Key_int[0] = LoadKey("Podaj klucz dla rotoru 1", Rotor1);
                        Key_int[1] = LoadKey("Podaj klucz dla rotoru 2", Rotor1);
                        Key_int[2] = LoadKey("Podaj klucz dla rotoru 3", Rotor1);


                        string Zdanie = WordsToEncript("\nPodaj zdanie do zaszyfrowania = ", Rotor1);

                        //szyfrowanie 
                        Console.Clear();
                        string Zdanie_Encript = EncriptMachine(EncriptKey(Key_int[0],Key_int[1],Key_int[2]), Zdanie, Rotor1, Rotor2);
                        Console.WriteLine("\nTwoje zdanie po zaszyfrowaniu wyglada nastepujaco :");
                        Console.WriteLine(Zdanie_Encript + "\n");
                        Console.WriteLine("Wiadomosc wyslana do oddzialow ! Aliantom tak latwo nie pojdzie zlamanie naszego szyfru ;-)");
                        // ------------------

                        Console.WriteLine("Czy zapisac plik ?  TAK/NIE <1,2>");
                        switch (PodajLiczbe("", 1, 2))
                        {
                            case 1:
                                

                                try
                                {
                                    
                                    using (StreamWriter Zapis = new StreamWriter(@"Zapis.txt",append: true))
                                    {
                                        Zapis.WriteLine(Zdanie_Encript);

                                    }
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine("Ups !, cos poszlo nie tak !");
                                    Console.WriteLine(e.Message);
                                   
                                }
                                Console.WriteLine("Pomyslnie dokonano zapisu");
                                break;
                            case 2:
                                Console.Clear();
                                break;


                        }

                        break;

                    case 2:

                        Key_int_Decript[0] = LoadKey("Podaj klucz dla rotoru 1", Rotor1);
                        Key_int_Decript[1] = LoadKey("Podaj klucz dla rotoru 2", Rotor1);
                        Key_int_Decript[2] = LoadKey("Podaj klucz dla rotoru 3", Rotor1);

                       
                        

                        string Zdanie_Decript = DecriptMachine(EncriptKey(Key_int_Decript[0], Key_int_Decript[1], Key_int_Decript[2]), WordsToEncript2("\nPodaj zdanie do deszyfracji =", Rotor1), Rotor1, Rotor2);
                        Console.Clear();
                        Console.WriteLine("Twoje zdanie po rozszyfrowaniu podanym kluczem to =");
                        Console.WriteLine(Zdanie_Decript + "\n");
                        Console.WriteLine("Mam nadzieje ze wiadomosc nie trafila do rak wroga !");

                        break;

                    case 3:
                        RysujInstrukcje();
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 4:
                        int Length =0;
                        string End = "";
                        Console.Clear();
                        try
                        {
                            using (StreamReader Zap1 = new StreamReader(@"Zapis.txt"))
                            {
                                string line;
                                int i = 1;
                              

                                while ((line = Zap1.ReadLine()) != null)
                                {

                                    Console.WriteLine(i + ". " + line);
                                    i++;
                                }
                                Length = i;
                                Zap1.Close();



                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        int Options = PodajLiczbe("Wybierz indeks ktory chcesz wczytac do maszyny =",1,Length);

                        try
                        {
                            using (StreamReader Zap2 = new StreamReader(@"Zapis.txt"))
                            {


                                int i = 1;
                                
                                int numer = Options;
                                string line = "";
                                
                                
                                while ((line = Zap2.ReadLine()) != null)
                                {


                                    if (i == numer)
                                    {
                                        End = line;
                                        break;
                                    }
                                    i++;
                                }
                                


                                Zap2.Close();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ups, cos poszlo nie tak !");
                            Console.WriteLine(e.Message);
                        }

                        Key_int_Decript[0] = LoadKey("Podaj klucz dla rotoru 1", Rotor1);
                        Key_int_Decript[1] = LoadKey("Podaj klucz dla rotoru 2", Rotor1);
                        Key_int_Decript[2] = LoadKey("Podaj klucz dla rotoru 3", Rotor1);

                        int orian = EncriptKey(Key_int_Decript[0], Key_int_Decript[1], Key_int_Decript[2]);
                        

                        string EndLine = DecriptMachine(EncriptKey(Key_int_Decript[0], Key_int_Decript[1], Key_int_Decript[2]), WordsToEncript2(End, Rotor1), Rotor1, Rotor2);
                        Console.Clear();
                        Console.WriteLine("Twoje zdanie po rozszyfrowaniu podanym kluczem to =");
                        Console.WriteLine(EndLine + "\n");
                        Console.WriteLine("Mam nadzieje ze wiadomosc nie trafila do rak wroga !");



                        break;


                    case 5:
                        Gra = false;
                            
                        break;

                }
               

            }
            Console.WriteLine("Nacisnij dowolny klawisz aby zakonczyc ...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            MainApp();
        }
    }
}






