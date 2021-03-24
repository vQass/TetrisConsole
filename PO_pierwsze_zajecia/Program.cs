﻿using System;

namespace PO_pierwsze_zajecia
{
    class Program
    {
        static void Main(string[] args)
        {
            //usuwanie linii nie dziala
            bool mozliwyRuch = true;
            bool dostepnyKlocek = false;
            bool gra = true;
            int czas = 0;
            int wymaganyCzas = 500;
            int punkty = 0;
            int wartoscZwracanegoCzasu = 0;
            Ruch ruch = Ruch.Stoj;
            Pozycja pozycja;
            Klocek klocek = new Klocek();
            Plansza plansza = new Plansza(10, 23, 3);
            //PlanszaDoUsuniecia.NadpiszPlansze(plansza);
            TablicaKsztaltow.InicjalizacjaTablicyBlokow();
            CyfryDoOdliczania.InicjalizacjaTablicyCyfr();
            Console.CursorVisible = false;

            while (true)
            {
                if (gra)
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
                        for (int i = 0; i < 2; i++)
                        {
                            if(Kolizje.KolizjaDol(klocek, plansza))
                            {
                                Gra.OpadanieKlocka(klocek);
                            }
                            else
                                break;

                        }
                            Wyswietlanie.WyswietlKlocek(klocek, plansza);
                    }

                    if (Console.KeyAvailable && mozliwyRuch)
                    {
                        ruch = Gra.AkcjaGracza();
                            switch (ruch)
                            {
                                case Ruch.Lewo:
                                case Ruch.Prawo:
                                case Ruch.Dol:
                                    if (Kolizje.KolizjaBoki(klocek, plansza, ruch))
                                    {
                                        Gra.RuchKlocka(klocek, ruch, ref wymaganyCzas);
                                        Wyswietlanie.UsunKlocek(klocek, plansza);
                                        Wyswietlanie.WyswietlKlocek(klocek, plansza);
                                    }
                                    break;
                                case Ruch.ObrotLewo:
                                case Ruch.ObrotPrawo:
                                    if (Kolizje.KolizjaObrot(klocek, plansza, ruch))
                                    {
                                        Gra.ObrotKlocka(klocek, ruch);
                                    Wyswietlanie.UsunKlocek(klocek, plansza);
                                        Wyswietlanie.WyswietlKlocek(klocek, plansza);
                                    }
                                    break;
                            }


                    }
                    else
                    {
                        wymaganyCzas = 500;
                    }

                    // liczenie czasu w sposob asynchroniczny
                    var watek = new System.Threading.Thread(() =>
                    {
                        System.Threading.Thread.Sleep(25);
                        wartoscZwracanegoCzasu = 25; // wartosc zwracana
                     });
                    watek.Start();
                    watek.Join();
                    czas += wartoscZwracanegoCzasu;
                    wartoscZwracanegoCzasu = 0;


                    if (czas >= wymaganyCzas)
                    {
                        czas = 0;
                        if (Kolizje.KolizjaDol(klocek, plansza))
                        {
                            Gra.OpadanieKlocka(klocek);
                            Wyswietlanie.UsunKlocek(klocek, plansza);
                            Wyswietlanie.WyswietlKlocek(klocek, plansza);
                            //mozliwyRuch = false;
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
                                gra = Gra.SprawdzCzyKoniecGry(plansza);
                                if (!gra)
                                    Wyswietlanie.PrzejscieKoniecGry(plansza);
                        }
                    }
                    else
                        mozliwyRuch = true;
                }
                if (!gra)
                {
                    Wyswietlanie.WyswietlKoniecGry(plansza);
                }
            }
        }
    }
}

