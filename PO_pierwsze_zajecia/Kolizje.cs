using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Kolizje
    {
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
                    if (temp[i, j] != 0)
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
    }
}
