using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Gra
    {
        private static List<Tetromino> tetrominos = new List<Tetromino>();

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

        public static void RuchKlocka(Tetromino klocek, Ruch ruch, ref int wymaganyCzas, bool klocekKolizja)
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
                    if(!klocekKolizja)
                        wymaganyCzas = 50;
                    break;
                case Ruch.Stoj:
                    break;
            }
        }

        public static Pozycja ZwrocObrotKlocka(Tetromino klocek, Ruch ruch)
        {
            Pozycja nowaPozycja = klocek.Pozycja;
            switch (ruch)
            {
                case Ruch.ObrotPrawo:
                    if ((int)nowaPozycja == 3)
                        nowaPozycja = 0;
                    else
                        nowaPozycja++;
                    break;
                case Ruch.ObrotLewo:
                    if ((int)nowaPozycja == 0)
                        nowaPozycja += 3;
                    else
                        nowaPozycja--;
                    break;
            }
            return nowaPozycja;
        }

        public static void ObrotKlocka(Tetromino klocek, Plansza plansza, Pozycja pozycja, int obrotNumerTestu, int[,] testy)
        {
            klocek.Pozycja = pozycja;
            Wyswietlanie.UsunKlocek(klocek, plansza);
            klocek.RogTablicyY += +testy[obrotNumerTestu, 1];
            klocek.RogTablicyX += testy[obrotNumerTestu, 0];
        }

        public static void DodajKlocekDoPlanszy(Tetromino klocek, Plansza plansza)
        {
            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(klocek.Pozycja, out temp);
            for (int i = 0; i < ((ITablica)klocek).Rozmiar; i++)
            {
                for (int j = 0; j < ((ITablica)klocek).Rozmiar; j++)
                {
                    if (temp[j, i] != 0 && (klocek.RogTablicyY + j + plansza.IleLiniiNiewidocznych) >= 0)
                    {
                        plansza.tab[klocek.RogTablicyX + i, klocek.RogTablicyY + j + plansza.IleLiniiNiewidocznych] = temp[j, i];
                    }
                }
            }
        }

        public static List<int> SprawdzLinie(Plansza plansza)
        {

            List<int> indeksy = new List<int>();
            //int ileLiniiUsunieto = 0;
            bool pelnaLinia = true;
            //bool usunietoLinie = false;
            for (int i = plansza.Wysokosc - 1; i >= 0; i--)
            {
                //pelnaLinia = true;
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    pelnaLinia = true;
                    if (plansza.tab[j, i] == 0)
                    {
                        pelnaLinia = false;
                        break;
                    }
                }
                if (pelnaLinia)
                {
                    indeksy.Add(i);
                }
            }
            return indeksy;
        }

        public static void UsunPelneLinie(Plansza plansza, List<int> indeksy)
        {
            //naprawic usuwanie 
            for (int i = 0; i < indeksy.Count; i++)
            {
                //for (int j = indeksy[i] + i; j >= 0; j--)
                //{
                    for (int k = indeksy[i] + i; k > 0; k--)
                    {

                        for (int l = 0; l < plansza.Szerokosc; l++)
                        {
                            plansza.tab[l, k] = plansza.tab[l, k - 1];
                        }
                    }
               // }
            }
        }

        public static void Punktacja(int ileLiniiUsunieto, ref int punkty)
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

        public static void OpadanieKlocka(Tetromino klocek)
        {

            klocek.RogTablicyY++;
        }

        public static Tetromino WylosujKlocek(Plansza plansza)
        {
            if (tetrominos.Count == 0)
            {
                tetrominos.Add(new KlocekT(plansza));
                tetrominos.Add(new KlocekS(plansza));
                tetrominos.Add(new KlocekZ(plansza));
                tetrominos.Add(new KlocekJ(plansza));
                tetrominos.Add(new KlocekL(plansza));
                tetrominos.Add(new KlocekI(plansza));
                tetrominos.Add(new KlocekO(plansza));
            }

            Random rnd = new Random((int)DateTime.Now.Ticks);
            int losowa = rnd.Next(0, tetrominos.Count);
            Tetromino temp = tetrominos[losowa];
            tetrominos.RemoveAt(losowa);
            return temp;
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

        public static int[,] WyznaczTesty(Tetromino klocek, Pozycja nastepnaPozycja, Ruch ruch, WallKicksIShape wallKicksIShape, WallKicksNonIShape wallKicksNonIShape)
        {
            int[,] tempTesty = new int[5, 2];
            if (klocek is KlocekI)
            {
                if (ruch == Ruch.ObrotLewo)
                    wallKicksIShape.ObrotWLewo.TryGetValue(nastepnaPozycja, out tempTesty);
                else
                    wallKicksIShape.ObrotWPrawo.TryGetValue(nastepnaPozycja, out tempTesty);
            }
            else
            {
                if (ruch == Ruch.ObrotLewo)
                    wallKicksNonIShape.ObrotWLewo.TryGetValue(nastepnaPozycja, out tempTesty);
                else
                    wallKicksNonIShape.ObrotWPrawo.TryGetValue(nastepnaPozycja, out tempTesty);
            }
            return tempTesty;
        }

        public static int[,] ZwrocTabliceObroconegoKlocka(Tetromino klocek, Pozycja nastepnaPozycja)
        {
            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(nastepnaPozycja, out temp);
            return temp;
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
