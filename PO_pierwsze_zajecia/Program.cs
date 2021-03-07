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
            Pozycja pozycja;
            Klocek klocek = new Klocek();
            Plansza plansza = new Plansza(10, 20);
            
            Gra.InicjalizacjaPlanszy(plansza);
            TablicaKsztaltow.InicjalizacjaTablicyBlokow();
            CyfryDoOdliczania.InicjalizacjaTablicyCyfr();


            while (true)
            {
                if(gra)
                {
                    Wyswietlanie.WyswietlTlo(plansza);
                    Wyswietlanie.WyswietlDodatkoweInformacje(plansza);
                    Wyswietlanie.CzekajNaReakcjeGracza(plansza);
                    Wyswietlanie.WyswietlPlansze(plansza);
                }
                while (gra)
                {
                    if (!dostepnyKlocek)
                    {
                        pozycja = Gra.WylosujKlocek();
                        dostepnyKlocek = true;
                        klocek = new Klocek(plansza, pozycja);
                        Wyswietlanie.WyswietlKlocek(klocek, plansza);
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
                                    if(Kolizje.KolizjaBoki(klocek, plansza, ruch))
                                        Gra.RuchKlocka(klocek, ruch, ref wymaganyCzas);
                                    break;
                                case Ruch.ObrotLewo:
                                case Ruch.ObrotPrawo:
                                    if (Kolizje.KolizjaObrot(klocek, plansza, ruch))
                                        Gra.ObrotKlocka(klocek, ruch);
                                    break;
                            }
  
                        }
                    }
                    else
                    {
                        wymaganyCzas = 500;
                    }

                    Wyswietlanie.UsunKlocek(klocek, plansza);
                    Wyswietlanie.WyswietlKlocek(klocek, plansza);
                    System.Threading.Thread.Sleep(50);

                    czas += 50;
                    if (czas >= wymaganyCzas)
                    {
                        mozliwyRuch = false;
                        czas = 0;
                        if (Kolizje.KolizjaDol(klocek, plansza))
                        {
                            Gra.OpadanieKlocka(klocek);
                        }
                        else
                        {
                            Gra.DodajKlocekDoPlanszy(klocek, plansza);
                            dostepnyKlocek = false;
                            if (Gra.SprawdzLinie(plansza, ref punkty))
                            {
                                Wyswietlanie.WyswietlPlansze(plansza);
                                Wyswietlanie.AktualizacjaPunktow(plansza, punkty);
                            }
                        }
                        gra = Gra.KoniecGry(plansza);
                    }
                    else
                    {
                        mozliwyRuch = true;
                    }
                }
                if(!gra)
                {
                    Wyswietlanie.WyswietlKoniecGry(plansza);
                }
            }
        }
    }
}

