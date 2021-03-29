using System;
using System.Collections.Generic;

namespace PO_pierwsze_zajecia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool klocekKolizja = false;
            bool dostepnyKlocek = false;
            bool gra = true;
            int czas = 0;
            int wymaganyCzas = 500;
            int punkty = 0;
            int wartoscZwracanegoCzasu = 0;
            int obrotNumerTestu = 0;
            Ruch ruch = Ruch.Stoj;
            Tetromino klocek = null;
            Plansza plansza = new Plansza(10, 23, 3);
            WallKicksNonIShape wallKicksNonIShape = new WallKicksNonIShape();
            WallKicksIShape wallKicksIShape = new WallKicksIShape();
            //PlanszaDoUsuniecia.UzupelnijPlansze(plansza);
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

                        dostepnyKlocek = true;
                        klocek = Gra.WylosujKlocek(plansza);
                        //klocek = new KlocekT(plansza); //do testowania wallkickow
                        for (int i = 0; i < 3; i++)
                        {
                            if (Kolizje.KolizjaDol(klocek, plansza))
                            {
                                Gra.OpadanieKlocka(klocek);
                            }
                            else
                                break;

                        }
                        Wyswietlanie.WyswietlKlocek(klocek, plansza);
                    }

                    if (Console.KeyAvailable)
                    {
                        ruch = Gra.AkcjaGracza();
                        switch (ruch)
                        {
                            case Ruch.Lewo:
                            case Ruch.Prawo:
                            case Ruch.Dol:
                                if (Kolizje.KolizjaBoki(klocek, plansza, ruch))
                                {
                                    Gra.RuchKlocka(klocek, ruch, ref wymaganyCzas, klocekKolizja);
                                    Wyswietlanie.UsunKlocek(klocek, plansza);
                                    Wyswietlanie.WyswietlKlocek(klocek, plansza);
                                }
                                break;
                            case Ruch.ObrotLewo:
                            case Ruch.ObrotPrawo:
                                Pozycja nastepnaPozycja = Gra.ZwrocObrotKlocka(klocek, ruch);
                                if (Kolizje.KolizjaObrot(klocek, plansza, Gra.ZwrocTabliceObroconegoKlocka(klocek, nastepnaPozycja), ref obrotNumerTestu, Gra.WyznaczTesty(klocek, nastepnaPozycja, ruch, wallKicksIShape, wallKicksNonIShape)))
                                {
                                    Gra.ObrotKlocka(klocek, plansza, Gra.ZwrocObrotKlocka(klocek, ruch), obrotNumerTestu, Gra.WyznaczTesty(klocek, nastepnaPozycja, ruch, wallKicksIShape, wallKicksNonIShape));
                                    Wyswietlanie.WyswietlKlocek(klocek, plansza);
                                }
                                obrotNumerTestu = 0;
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
                            klocekKolizja = false;
                            Gra.OpadanieKlocka(klocek);
                            Wyswietlanie.UsunKlocek(klocek, plansza);
                            Wyswietlanie.WyswietlKlocek(klocek, plansza);
                        }
                        else
                        {
                            if (wymaganyCzas == 500)
                            {
                                Gra.DodajKlocekDoPlanszy(klocek, plansza);
                                dostepnyKlocek = false;
                                List<int> temp = Gra.SprawdzLinie(plansza);
                                if (temp.Count > 0)
                                {
                                    Wyswietlanie.WyswietlUsuwaneLinie(plansza, temp);
                                    Gra.UsunPelneLinie(plansza, temp);
                                    Gra.Punktacja(temp.Count, ref punkty);
                                    Wyswietlanie.WyswietlPlansze(plansza);
                                    Wyswietlanie.AktualizacjaPunktow(plansza, punkty);
                                }
                                gra = Gra.SprawdzCzyKoniecGry(plansza);
                                if (!gra)
                                    Wyswietlanie.PrzejscieKoniecGry(plansza);
                            }
                            else
                            {
                                wymaganyCzas = 500;
                                klocekKolizja = true;
                            }
                        }
                    }
                }
                if (!gra)
                {
                    Wyswietlanie.WyswietlKoniecGry(plansza);
                }
            }
        }
    }
}

