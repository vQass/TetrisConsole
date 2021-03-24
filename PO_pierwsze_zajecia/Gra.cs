using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Gra
    {
        public static Ruch AkcjaGracza()
        {
            Ruch ruch = new Ruch();
            ConsoleKeyInfo klawisz = Console.ReadKey(true);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            switch (klawisz.Key)
            {
                case ConsoleKey.LeftArrow:
                    ruch = Ruch.Lewo;
                    break;
                case ConsoleKey.RightArrow:
                    ruch = Ruch.Prawo;
                    break;
                case ConsoleKey.UpArrow:
                    ruch = Ruch.ObrotPrawo;
                    break;
                case ConsoleKey.DownArrow:
                    ruch = Ruch.Dol;
                    break;
                case ConsoleKey.Z:
                    ruch = Ruch.ObrotLewo;
                    break;
                case ConsoleKey.X:
                    ruch = Ruch.ObrotPrawo;
                    break;
                default:
                    ruch = Ruch.Stoj;
                    break;
            }
            return ruch;
        }

        public static void RuchKlocka(Klocek klocek, Ruch ruch, ref int wymaganyCzas)
        {
            switch (ruch)
            {
                case Ruch.Lewo:
                    klocek.RogTablicyX--;
                    break;
                case Ruch.Prawo:
                    klocek.RogTablicyX++;
                    break;
                case Ruch.Dol:
                    wymaganyCzas = 50;
                    break;
                case Ruch.Stoj:
                    break;
            }
        }

        public static void ObrotKlocka(Klocek klocek, Ruch ruch)
        {
            switch (ruch)
            {
                case Ruch.ObrotLewo:
                    if ((int)klocek.Pozycja % 4 == 3)
                        klocek.Pozycja -= 3;
                    else
                        klocek.Pozycja++;
                    break;
                case Ruch.ObrotPrawo:
                    if ((int)klocek.Pozycja % 4 == 0)
                        klocek.Pozycja += 3;
                    else
                        klocek.Pozycja--;
                    break;
            }
        }

        public static void DodajKlocekDoPlanszy(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(klocek.Pozycja, out temp);
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    if (temp[j, i] != 0 && (klocek.RogTablicyY + j + plansza.IleLiniiNiewidocznych) >= 0)
                    {
                        plansza.tab[klocek.RogTablicyX + i, klocek.RogTablicyY + j + plansza.IleLiniiNiewidocznych] = temp[j, i];
                    }
                }
            }
        }

        public static bool SprawdzLinie(Plansza plansza, ref int punkty)
        {
            int ileLiniiUsunieto = 0;
            bool pelnaLinia = true;
            bool usunietoLinie = false;
            for (int i = plansza.Wysokosc - 1; i >= 0; i--)
            {
                pelnaLinia = true;
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    //pelnaLinia = true;
                    if (plansza.tab[j, i] == 0)
                    {
                        pelnaLinia = false;
                        break;
                    }
                }
                if (pelnaLinia)
                {
                    ileLiniiUsunieto++;
                }
                if (pelnaLinia)
                {
                    usunietoLinie = true;
                    for (int j = i; j > 0; j--)
                    {
                        for (int k = 0; k < plansza.Szerokosc; k++)
                        {
                            plansza.tab[k, j] = plansza.tab[k, j - 1];
                        }
                    }
                    i++;
                }
            }
            Punktacja(ileLiniiUsunieto, ref punkty);
            return usunietoLinie;
        }

        private static void Punktacja(int ileLiniiUsunieto, ref int punkty)
        {
            switch (ileLiniiUsunieto)
            {
                case 1:
                    punkty += 40;
                    break;
                case 2:
                    punkty += 100;
                    break;
                case 3:
                    punkty += 300;
                    break;
                case 4:
                    punkty += 1200;
                    break;
            }
        }

        public static void OpadanieKlocka(Klocek klocek)
        {

            klocek.RogTablicyY++;
        }

        public static Pozycja WylosujKlocek()
        {
            Pozycja pozycja = Pozycja.T1;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int losowa = rnd.Next(1, 8);
            switch (losowa)
            {
                case 1:
                    pozycja = Pozycja.T1;
                    break;
                case 2:
                    pozycja = Pozycja.S1;
                    break;
                case 3:
                    pozycja = Pozycja.Z1;
                    break;
                case 4:
                    pozycja = Pozycja.J1;
                    break;
                case 5:
                    pozycja = Pozycja.L1;
                    break;
                case 6:
                    pozycja = Pozycja.I1;
                    break;
                case 7:
                    pozycja = Pozycja.O1;
                    break;
            }
            return pozycja;
        }

        public static bool KoniecGry(Plansza plansza)
        {
            bool koniecGry = false;
            for (int i = 0; i < plansza.tab.GetLength(0); i++)
            {
                if (plansza.tab[i, 1] != 0)
                    koniecGry = true;
            }
            return !koniecGry;
        }

        public static bool SprawdzCzyKoniecGry(Plansza plansza)
        {
            for (int i = 0; i < plansza.Szerokosc; i++)
            {
                if (plansza.tab[i, plansza.IleLiniiNiewidocznych - 1] != 0)
                    return false;
            }
            return true;
        }

        public static ConsoleColor ZwrocKolor(int liczba)
        {
            ConsoleColor kolor = ConsoleColor.Black;
            switch (liczba)
            {
                case 0:
                    kolor = ConsoleColor.Gray;
                    break;
                case 1:
                    kolor = ConsoleColor.DarkMagenta;
                    break;
                case 2:
                    kolor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    kolor = ConsoleColor.DarkRed;
                    break;
                case 4:
                    kolor = ConsoleColor.DarkBlue;
                    break;
                case 5:
                    kolor = ConsoleColor.DarkYellow;
                    break;
                case 6:
                    kolor = ConsoleColor.DarkCyan;
                    break;
                case 7:
                    kolor = ConsoleColor.Yellow;
                    break;
            }
            return kolor;
        }

    }


    enum Ruch
    {
        Lewo,
        Prawo,
        Dol,
        ObrotLewo,
        ObrotPrawo,
        Stoj
    }
}
