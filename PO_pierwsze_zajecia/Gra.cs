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
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
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
                        Console.BackgroundColor = ConsoleColor.Green;
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WyswietlPlansze2(Plansza plansza)
        {
            for (int i = 0; i < plansza.tab.GetLength(1); i++)
            {
                Console.SetCursorPosition(25, i);
                for (int j = 0; j < plansza.tab.GetLength(0); j++)
                {

                    //if (plansza.tab[j, i] == 0)
                    //    Console.BackgroundColor = ConsoleColor.Green;
                    //else
                    //{
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //}

                    Console.Write(plansza.tab[j, i]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WyswietlKlocek(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            klocek.klocki.TryGetValue(klocek.Pozycja, out temp);
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    Console.SetCursorPosition((klocek.RogTablicyX + i + 1) * 2, klocek.RogTablicyY + j);
                    if (temp[j, i] != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
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
            klocek.klocki.TryGetValue(klocek.poprzedniaPozycja, out temp);
            for (int i = 0; i < Klocek.ROZMIAR_BLOKU; i++)
            {
                for (int j = 0; j < Klocek.ROZMIAR_BLOKU; j++)
                {
                    Console.SetCursorPosition((klocek.poprzedniRogTablicyX + i + 1) * 2, klocek.poprzedniRogTablicyY + j);
                    if (temp[j, i] != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
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
                    ruch = Ruch.ObrotLewo;
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
                case Ruch.ObrotLewo:
                    if (klocek.Pozycja == Pozycja.T4)
                        klocek.Pozycja = Pozycja.T1;
                    else
                        klocek.Pozycja++;
                    break;
                case Ruch.ObrotPrawo:
                    if (klocek.Pozycja == Pozycja.T1)
                        klocek.Pozycja = Pozycja.T4;
                    else
                        klocek.Pozycja--;
                    break;
                case Ruch.Stoj:
                    break;
            }
        }

        public static bool KolizjaBoki(Klocek klocek, Plansza plansza, Ruch ruch)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            klocek.klocki.TryGetValue(klocek.Pozycja, out temp);
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
                                if (j + klocek.RogTablicyX == 0 || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] == 1)
                                {
                                    return false;
                                }

                                //sprawdzanie kolizji krok po kroku
                                //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                                //Console.BackgroundColor = ConsoleColor.Cyan;
                                //Console.WriteLine("  ");
                                //System.Threading.Thread.Sleep(500);
                                break; //sprawdzic czy dziala z breakiem przy gotowym tetrisie

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
                                if (j + klocek.RogTablicyX + 1 == plansza.tab.GetLength(0) || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] == 1)
                                {
                                    return false;
                                }

                                //sprawdzanie kolizji krok po kroku
                                //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                                //Console.BackgroundColor = ConsoleColor.Cyan;
                                //Console.WriteLine("  ");
                                //System.Threading.Thread.Sleep(500);
                                break; //sprawdzic czy dziala z breakiem przy gotowym tetrisie

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
            klocek.klocki.TryGetValue(klocek.Pozycja, out temp);
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

        public static void DodajKlocekDoPlanszy(Klocek klocek, Plansza plansza)
        {
            int[,] temp = new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU];
            klocek.klocki.TryGetValue(klocek.Pozycja, out temp);
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
            Console.WriteLine("Obrot w prawo - X");
            Console.SetCursorPosition((plansza.tab.GetLength(0) + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 9);
            Console.WriteLine("Obrot w lewo - ↑ lub Z");
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
