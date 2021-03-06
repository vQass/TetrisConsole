using System;

namespace PO_pierwsze_zajecia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool dostepnyKlocek = true;
            bool gra = true;
            bool mozliwyRuch = true; // zmienna potrzebna do poprawnego dzialania metody UsunKlocek
            int czas = 0;
            int wymaganyCzas = 500;
            int punkty = 0;
            Ruch ruch = Ruch.Stoj;
            Plansza plansza = new Plansza(10,  20);
            Gra.Inicjalizacja(plansza);
            Gra.WyswietlTlo(plansza);
            Gra.WyswietlPlansze(plansza);
            Gra.WyswietlDodatkoweInformacje(plansza);
            Klocek klocek = new Klocek(plansza);
            Console.ReadKey(true);
            Gra.UsunNapisDowolnyKlawisz(plansza);
            while (gra)
            {
                if (!dostepnyKlocek)
                {
                    dostepnyKlocek = true;
                    klocek = new Klocek(plansza);
                    Gra.WyswietlKlocek(klocek, plansza);
                }

                if (Console.KeyAvailable)
                {
                    ruch = Gra.AkcjaGracza();
                    if (mozliwyRuch && Gra.KolizjaBoki(klocek, plansza, ruch))
                    {
                        Gra.RuchKlocka(klocek, ruch, ref wymaganyCzas);
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
                    if(Gra.KolizjaDol(klocek, plansza))
                    {
                    Gra.OpadanieKlocka(klocek);

                    }
                    else
                    {
                        Gra.DodajKlocekDoPlanszy(klocek, plansza);
                        dostepnyKlocek = false;
                        //Gra.WyswietlPlansze2(plansza);
                        if(Gra.SprawdzLinie(plansza, ref punkty))
                        {
                            Gra.WyswietlPlansze(plansza);
                            Gra.AktualizacjaPunktow(plansza, punkty);
                        } 
                    }
                }
                else
                {
                    mozliwyRuch = true;
                }
            }
        }
    }
}

