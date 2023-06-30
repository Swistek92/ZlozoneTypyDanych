using System.Collections.Immutable;
using System.Runtime.ExceptionServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace zad3
{
    internal class zadanie3
    {

        enum KlasaRzadkosci
        {
            Powrzechny =1,
            Rzadki,
            Unikalny,
            Epicki,
        }
        enum TypPrzedmiotu
        {
            Bron,
            Zbroja,
            Amulet,
            Pierscien,
            Helm,
            Tarcza,
            Buty,
        }

        struct Przedmiot
        {
            public float Waga;
            public int Wartosc;
            public string Nazwa;
            public KlasaRzadkosci Rzadkosc;
            public TypPrzedmiotu Typ;
        }

        class Program
        {
            static void Main()
            {
                Przedmiot[] przedmioty = new Przedmiot[3];


                WypelnijPrzedmiot(ref przedmioty[0], 1.5f, 10, "Tarcza Łowy Smoków", KlasaRzadkosci.Rzadki, TypPrzedmiotu.Tarcza);
                WypelnijPrzedmiot(ref przedmioty[1], 1.5f, 10, "zardzewiała Tarcza", KlasaRzadkosci.Rzadki, TypPrzedmiotu.Tarcza);
                WypelnijPrzedmiot(ref przedmioty[2], 1.5f, 10, "Tarcza Paladyna", KlasaRzadkosci.Rzadki, TypPrzedmiotu.Tarcza);

                Przedmiot wylosowany = LosujPrzedmiot(przedmioty);

                WyswietlPrzedmiot(wylosowany);
            }






            static Przedmiot LosujPrzedmiot(Przedmiot[] Skrzynka) {
            
                Random random = new Random();

                Array.Sort(Skrzynka, PorownajPrzedmioty);
                int sumaRzadkosci = 0;
                foreach(Przedmiot przedmiot in Skrzynka)
                    {
                    sumaRzadkosci += (int)przedmiot.Rzadkosc;
                    }
                int losowanie = random.Next(1, sumaRzadkosci + 1);
                int aktualnaSuma = 0;

                foreach(var przedmiot in Skrzynka)
                {
                    aktualnaSuma += (int)przedmiot.Rzadkosc;
                    if (aktualnaSuma >= losowanie)
                    {
                        return przedmiot;
                    }


                }
                return Skrzynka[0];



            }

            static int PorownajPrzedmioty(Przedmiot p1, Przedmiot p2)
            {
                if (p1.Rzadkosc< p2.Rzadkosc)
                {
                    return -1;
                }else if( p1.Rzadkosc == p2.Rzadkosc)
                {
                    return 0;
                }else
                {
                    return 1;
                }
            }


            static void WyswietlPrzedmiot(Przedmiot Przedmiot)
            {
                Console.WriteLine($"Przedmiot: {Przedmiot.Nazwa}");
                Console.WriteLine($"Rzadkosc: {Przedmiot.Rzadkosc}");
                Console.WriteLine();    

            }


            static void WypelnijPrzedmiot(
                ref Przedmiot Przedmiot,
                float Waga,
                int Wartosc,
                string Nazwa,
                KlasaRzadkosci Rzadkosc,
                TypPrzedmiotu Typ
                ) {
                if (Waga >= 0)
                {
                    Przedmiot.Waga = Waga;
                }else
                {
                    Przedmiot.Waga = 0;
                }

                if (Wartosc >= 0)
                {
                    Przedmiot.Wartosc = Wartosc;
                }
                else
                {
                    Przedmiot.Wartosc = 0;
                }
                Przedmiot.Nazwa = Nazwa; 
                Przedmiot.Rzadkosc = Rzadkosc;
                Przedmiot.Typ= Typ;

            }


        
        }

    }
}
