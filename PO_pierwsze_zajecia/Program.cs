using System;

namespace PO_pierwsze_zajecia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool dostepnyKlocek = false;
            bool gra = true;
            bool mozliwyRuch = true; // zmienna potrzebna do poprawnego dzialania metody UsunKlocek
            int czas = 0;
            int wymaganyCzas = 500;
            int punkty = 0;
            Ruch ruch = Ruch.Stoj;
            Plansza plansza = new Plansza(10, 20);
            Gra.Inicjalizacja(plansza);
            TablicaKsztaltow.WypelnijTablice();
            Gra.WyswietlTlo(plansza);
            Gra.WyswietlPlansze(plansza);
            Gra.WyswietlDodatkoweInformacje(plansza);
            Pozycja pozycja;
            Klocek klocek = new Klocek();
            Console.ReadKey(true);
            Gra.UsunNapisDowolnyKlawisz(plansza);
            while (true)
            {
                while (gra)
                {
                    if (!dostepnyKlocek)
                    {
                        pozycja = Gra.WylosujKlocek();
                        dostepnyKlocek = true;
                        klocek = new Klocek(plansza, pozycja);
                        Gra.WyswietlKlocek(klocek, plansza);
                    }

                    if (Console.KeyAvailable)
                    {
                        ruch = Gra.AkcjaGracza();
                        if (mozliwyRuch)
                        {
                            switch(ruch)
                            {
                                case Ruch.Lewo:
                                case Ruch.Prawo:
                                case Ruch.Dol:
                                    if(Gra.KolizjaBoki(klocek, plansza, ruch))
                                        Gra.RuchKlocka(klocek, ruch, ref wymaganyCzas);
                                    break;
                                case Ruch.ObrotLewo:
                                case Ruch.ObrotPrawo:
                                    if (Gra.KolizjaObrot(klocek, plansza, ruch))
                                        Gra.ObrotKlocka(klocek, ruch);
                                    break;
                            }
  
                        }
                    }
                    else
                    {
                        wymaganyCzas = 500;
                    }

                    Gra.UsunKlocek(klocek, plansza);
                    Gra.WyswietlKlocek(klocek, plansza);
                    System.Threading.Thread.Sleep(50);

                    czas += 50;
                    if (czas >= wymaganyCzas)
                    {
                        mozliwyRuch = false;
                        czas = 0;
                        if (Gra.KolizjaDol(klocek, plansza))
                        {
                            Gra.OpadanieKlocka(klocek);
                        }
                        else
                        {
                            Gra.DodajKlocekDoPlanszy(klocek, plansza);
                            dostepnyKlocek = false;
                            if (Gra.SprawdzLinie(plansza, ref punkty))
                            {
                                Gra.WyswietlPlansze(plansza);
                                Gra.AktualizacjaPunktow(plansza, punkty);
                            }
                        }
                        gra = Gra.KoniecGry(plansza);
                    }
                    else
                    {
                        mozliwyRuch = true;
                    }
                }
                Console.SetCursorPosition(0, 0);
                Gra.WyswietlTlo(plansza);
                string napisKoncaGry = "Game Over!";
                Console.SetCursorPosition((2 +  plansza.tab.GetLength(0) - napisKoncaGry.Length / 2) , plansza.tab.GetLength(1) / 2);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(napisKoncaGry);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ReadKey();
            }
        }
    }
}

