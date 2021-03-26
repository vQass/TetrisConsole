using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Kolizje
    {
        public static bool KolizjaBoki(Tetromino klocek, Plansza plansza, Ruch ruch)
        {
            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(klocek.Pozycja, out temp);
            int wysokoscSprawdzania;
            int szerokoscSprawdzania;
            switch (ruch)
            {
                case Ruch.Lewo:
                    for (int i = 0; i < ((ITablica)klocek).Rozmiar; i++)
                    {
                        for (int j = 0; j < ((ITablica)klocek).Rozmiar; j++)
                        {
                            if (temp[i, j] != 0)
                            {
                                wysokoscSprawdzania = klocek.RogTablicyY + i + plansza.IleLiniiNiewidocznych;
                                szerokoscSprawdzania = klocek.RogTablicyX + j - 1;
                                if (j + klocek.RogTablicyX == 0)
                                {
                                    return false;
                                }
                                if (wysokoscSprawdzania >= 0)
                                {
                                    if (plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] != 0)
                                        return false;
                                    //sprawdzanie kolizji krok po kroku
                                    //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                                    //Console.BackgroundColor = ConsoleColor.Cyan;
                                    //Console.WriteLine("  ");
                                    //System.Threading.Thread.Sleep(50);
                                    //break;
                                }
                            }
                        }
                    }
                    break;
                case Ruch.Prawo:
                    for (int i = ((ITablica)klocek).Rozmiar - 1; i >= 0; i--)
                    {
                        for (int j = ((ITablica)klocek).Rozmiar - 1; j >= 0; j--)
                        {
                            if (temp[i, j] != 0)
                            {
                                wysokoscSprawdzania = klocek.RogTablicyY + i + plansza.IleLiniiNiewidocznych;
                                szerokoscSprawdzania = klocek.RogTablicyX + j + 1;
                                if (j + klocek.RogTablicyX + 1 == plansza.tab.GetLength(0))
                                {
                                    return false;
                                }
                                if (wysokoscSprawdzania >= 0)
                                {
                                    if (plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania] != 0)
                                        return false;
                                    //sprawdzanie kolizji krok po kroku
                                    //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                                    //Console.BackgroundColor = ConsoleColor.Cyan;
                                    //Console.WriteLine("  ");
                                    //System.Threading.Thread.Sleep(50);
                                }
                                break;
                            }
                        }
                    }
                    break;
            }
            return true;
        }
        public static bool KolizjaDol(Tetromino klocek, Plansza plansza)
        {

            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(klocek.Pozycja, out temp);
            int wysokoscSprawdzania;
            int szerokoscSprawdzania;
            for (int i = 0; i < ((ITablica)klocek).Rozmiar; i++)
            {
                for (int j = 0; j < ((ITablica)klocek).Rozmiar; j++)
                {
                    if (temp[i, j] != 0)
                    {
                        wysokoscSprawdzania = klocek.RogTablicyY + i + 1;
                        szerokoscSprawdzania = klocek.RogTablicyX + j;

                        if (wysokoscSprawdzania >= 0)
                        {
                            //sprawdzanie kolizji krok po kroku
                            //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                            //Console.BackgroundColor = ConsoleColor.Cyan;
                            //Console.WriteLine("  ");
                            //System.Threading.Thread.Sleep(1000);
                            if (wysokoscSprawdzania == plansza.Wysokosc - plansza.IleLiniiNiewidocznych || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania + plansza.IleLiniiNiewidocznych] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static bool KolizjaObrot(Tetromino klocek, Plansza plansza, Ruch ruch)
        {
            Pozycja nastepnaPozycja = Gra.ZwrocObrotKlocka(klocek, ruch);
            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(nastepnaPozycja, out temp);
            int wysokoscSprawdzania = klocek.RogTablicyY;
            int szerokoscSprawdzania = klocek.RogTablicyX;

            for (int i = 0; i < ((ITablica)klocek).Rozmiar; i++)
            {
                for (int j = 0; j < ((ITablica)klocek).Rozmiar; j++)
                {
                    if (temp[i, j] != 0)
                    {
                        wysokoscSprawdzania = klocek.RogTablicyY + i;
                        szerokoscSprawdzania = klocek.RogTablicyX + j;
                        if (wysokoscSprawdzania >= 0)
                        {
                            if (wysokoscSprawdzania >= (plansza.Wysokosc - plansza.IleLiniiNiewidocznych) || szerokoscSprawdzania >= plansza.Szerokosc || szerokoscSprawdzania <= -1 || plansza.tab[szerokoscSprawdzania, wysokoscSprawdzania + plansza.IleLiniiNiewidocznych] != 0)
                                return false;
                            //sprawdzanie kolizji krok po kroku
                            //Console.SetCursorPosition((szerokoscSprawdzania + 1) * 2, wysokoscSprawdzania);
                            //Console.BackgroundColor = ConsoleColor.Cyan;
                            //Console.Write("  ");
                            //System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
            }
            return true;
        }
    }
}
