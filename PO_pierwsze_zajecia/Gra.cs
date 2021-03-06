using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Gra
    {
        public static void Inicjalizacja(Plansza plansza)
        {
            for (int i = 0; i < plansza.tab.GetLength(1); i++)
            {
                for (int j = 0; j < plansza.tab.GetLength(0); j++)
                {
                    plansza.tab[j, i] = 0;
                }
            }
        }

        public static void WyswietlTlo(Plansza plansza)
        {
            for (int i = 0; i < plansza.tab.GetLength(1) + 1; i++)
            {
                for (int j = 0; j < plansza.tab.GetLength(0) + 2; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void WyswietlPlansze(Plansza plansza)
        {
            for (int i = 0; i < plansza.tab.GetLength(1); i++)
            {
                Console.SetCursorPosition(2, i);
                for (int j = 0; j < plansza.tab.GetLength(0); j++)
                {
                    if (plansza.tab[j, i] == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                    {
                        switch (plansza.tab[j, i])
                        {
                            case 1:
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;
                            case 4:
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 5:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 6:
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 7:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                        }
                    }

                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WyswietlKlocek(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(klocek.Pozycja, out temp);
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    if (temp[j, i] != 0)
                    {
                    Console.SetCursorPosition((klocek.RogTablicyX + i + 1) * 2, klocek.RogTablicyY + j);
                        switch (temp[j, i])
                        {
                            case 1:
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;
                            case 4:
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 5:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 6:
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 7:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                        }
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.SetCursorPosition(0, plansza.tab.GetLength(1));
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static void UsunKlocek(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(klocek.poprzedniaPozycja, out temp);
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    if (temp[j, i] != 0)
                    {
                    Console.SetCursorPosition((klocek.poprzedniRogTablicyX + i + 1) * 2, klocek.poprzedniRogTablicyY + j);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("  ");
                    }
                }
                Console.SetCursorPosition(0, plansza.tab.GetLength(1));
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public static void OpadanieKlocka(Klocek klocek)
        {

            klocek.RogTablicyY++;
        }

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

        public static bool KolizjaBoki(Klocek klocek, Plansza plansza, Ruch ruch)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(klocek.Pozycja, out temp);
            int wysokoscSprawdzania;
            int szerokoscSprawdzania;
            switch (ruch)
            {
                case Ruch.Lewo:
                    for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
                    {
                        for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                        {
                            if (temp[i, j] != 0)
                            {
                                wysokoscSprawdzania = klocek.RogTablicyY + i;
                                szerokoscSprawdzania = klocek.RogTablicyX + j - 1;
                                if (j + klocek.RogTablicyX == 0 || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] != 0)
                                {
                                    return false;
                                }

                                //sprawdzanie kolizji krok po kroku
                                //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                                //Console.BackgroundColor = ConsoleColor.Cyan;
                                //Console.WriteLine("  ");
                                //System.Threading.Thread.Sleep(50);
                                break;

                            }
                        }
                    }
                    break;
                case Ruch.Prawo:
                    for (int i = Klocek.ROZMIAR_BLOKU - 1; i >= 0; i--)
                    {
                        for (int j = Klocek.ROZMIAR_BLOKU - 1; j >= 0; j--)
                        {
                            if (temp[i, j] != 0)
                            {
                                wysokoscSprawdzania = klocek.RogTablicyY + i;
                                szerokoscSprawdzania = klocek.RogTablicyX + j + 1;
                                if (j + klocek.RogTablicyX + 1 == plansza.tab.GetLength(0) || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] != 0)
                                {
                                    return false;
                                }

                                //sprawdzanie kolizji krok po kroku
                                //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                                //Console.BackgroundColor = ConsoleColor.Cyan;
                                //Console.WriteLine("  ");
                                //System.Threading.Thread.Sleep(50);
                                break;

                            }
                        }
                    }
                    break;
            }
            return true;
        }
        public static bool KolizjaDol(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(klocek.Pozycja, out temp);
            int wysokoscSprawdzania;
            int szerokoscSprawdzania;
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    if (temp[i, j] != 0)
                    {
                        wysokoscSprawdzania = klocek.RogTablicyY + i + 1;
                        szerokoscSprawdzania = klocek.RogTablicyX + j;
                        if (wysokoscSprawdzania == plansza.tab.GetLength(1) || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static bool KolizjaObrot(Klocek klocek, Plansza plansza, Ruch ruch)
        {
            Pozycja nastepnaPozycja = klocek.Pozycja;
            switch (ruch)
            {
                case Ruch.ObrotLewo:
                    if ((int)nastepnaPozycja % 4 == 3)
                        nastepnaPozycja -= 3;
                    else
                        nastepnaPozycja++;
                    break;
                case Ruch.ObrotPrawo:
                    if ((int)nastepnaPozycja % 4 == 0)
                        nastepnaPozycja += 3;
                    else
                        nastepnaPozycja--;
                    break;
            }
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(nastepnaPozycja, out temp);
            int wysokoscSprawdzania = klocek.RogTablicyY;
            int szerokoscSprawdzania = klocek.RogTablicyX;

            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    if(temp[i, j] != 0)
                    {
                    wysokoscSprawdzania = klocek.RogTablicyY + i;
                    szerokoscSprawdzania = klocek.RogTablicyX + j;
                    if (wysokoscSprawdzania >= plansza.tab.GetLength(1) || szerokoscSprawdzania >= plansza.tab.GetLength(0) || szerokoscSprawdzania <= -1 || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] != 0)
                        return false;
                        //sprawdzanie kolizji krok po kroku
                        //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                        //Console.BackgroundColor = ConsoleColor.Cyan;
                        //Console.Write("  ");
                        //System.Threading.Thread.Sleep(1000);
                    }     
                }
            }
            return true;
        }

        public static void DodajKlocekDoPlanszy(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            TablicaKsztaltow.klocki.TryGetValue(klocek.Pozycja, out temp);
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    if (temp[j, i] != 0)
                    {
                        plansza.tab[klocek.RogTablicyX + i, klocek.RogTablicyY + j] = temp[j, i];
                    }
                }
            }
        }

        public static bool SprawdzLinie(Plansza plansza, ref int punkty)
        {
            int ileLiniiUsunieto = 0;
            bool pelnaLinia = true;
            bool usunietoLinie = false;
            for (int i = plansza.tab.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = 0; j < plansza.tab.GetLength(0); j++)
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
                    ileLiniiUsunieto++;
                }
                if (pelnaLinia)
                {
                    usunietoLinie = true;
                    for (int j = i; j > 0; j--)
                    {
                        for (int k = 0; k < plansza.tab.GetLength(0); k++)
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

        public static void WyswietlDodatkoweInformacje(Plansza plansza)
        {
            for (int i = 0; i < NapisTetris.napisTetris.GetLength(0); i++)
            {
                Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, i);
                for (int j = 0; j < NapisTetris.napisTetris.GetLength(1); j++)
                {
                    if (NapisTetris.napisTetris[i, j] == '#')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(NapisTetris.napisTetris[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 1);
            Console.Write("Punkty: 0");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 4);
            Console.Write("Sterowanie: ");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 5);
            Console.WriteLine("Lewo - ←");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 6);
            Console.WriteLine("Prawo - →");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 7);
            Console.WriteLine("Dol - ↓");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 8);
            Console.WriteLine("Obrot w prawo - ↑ lub X");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 9);
            Console.WriteLine("Obrot w lewo - Z");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 11);
            Console.WriteLine("Wcisnij dowolny klawisz aby zaczac");

        }

        public static void AktualizacjaPunktow(Plansza plansza, int punkty)
        {
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2 + 8, NapisTetris.napisTetris.GetLength(0) + 1);
            Console.Write(punkty);
        }

        public static void UsunNapisDowolnyKlawisz(Plansza plansza)
        {
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 11);
            Console.WriteLine("                                  ");
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
