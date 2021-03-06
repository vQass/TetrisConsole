using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Wyswietlanie
    {
        public static void WyswietlTlo(Plansza plansza)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = plansza.IleLiniiNiewidocznych; i < plansza.Wysokosc + 1; i++)
            {
                for (int j = 0; j < plansza.Szerokosc + 2; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WyswietlPlansze(Plansza plansza)
        {
            for (int i = plansza.IleLiniiNiewidocznych; i < plansza.Wysokosc; i++)
            {
                Console.SetCursorPosition(2, i - plansza.IleLiniiNiewidocznych);
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    Console.BackgroundColor = Gra.ZwrocKolor(plansza.tab[j, i]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void CzekajNaReakcjeGracza(Plansza plansza)
        {
            Console.ReadKey(true);
            UsunNapisDowolnyKlawisz(plansza);
            int szerokoscWyswietlania = plansza.Szerokosc - 1;
            int wysokoscWyswietlania = (plansza.Wysokosc - plansza.IleLiniiNiewidocznych) / 2  - 2;
            int[,] temp = new int[CyfryDoOdliczania.ROZMIAR_CYFRY, CyfryDoOdliczania.ROZMIAR_CYFRY];
            for (int i = 3; i >= 1; i--)
            {
                CyfryDoOdliczania.cyfry.TryGetValue(i, out temp);
                for (int j = 0; j < CyfryDoOdliczania.ROZMIAR_CYFRY; j++)
                {
                    for (int k = 0; k < CyfryDoOdliczania.ROZMIAR_CYFRY; k++)
                    {
                        if (temp[j, k] != 0)
                        {
                            Console.SetCursorPosition(szerokoscWyswietlania + k, wysokoscWyswietlania + j);
                            switch (temp[j, k])
                            {
                                case 1:
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case 2:
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case 3:
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    break;
                            }
                            Console.Write("  ");
                            
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.Black;
                Wyswietlanie.WyswietlTlo(plansza);
            }
        }

        public static void WyswietlKlocek(Tetromino klocek, Plansza plansza)
        {
            int wysokoscWyswietlania;
            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(klocek.Pozycja, out temp);
            for (int i = 0; i < ((ITablica)klocek).Rozmiar; i++)
            {
                for (int j = 0; j < ((ITablica)klocek).Rozmiar; j++)
                {
                    if (temp[j, i] != 0)
                    {
                        wysokoscWyswietlania = klocek.RogTablicyY + j;
                        if(wysokoscWyswietlania >= 0)
                        {
                            Console.SetCursorPosition((klocek.RogTablicyX + i + 1) * 2, wysokoscWyswietlania);
                            Console.BackgroundColor = Gra.ZwrocKolor(temp[j,i]);
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                }
                Console.SetCursorPosition(0, plansza.Wysokosc + 1 - plansza.IleLiniiNiewidocznych);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static void UsunKlocek(Tetromino klocek, Plansza plansza)
        {
            int wysokoscUsuwania;
            int[,] temp = new int[((ITablica)klocek).Rozmiar, ((ITablica)klocek).Rozmiar];
            ((ITablica)klocek).Tab.TryGetValue(klocek.poprzedniaPozycja, out temp);
            for (int i = 0; i < ((ITablica)klocek).Rozmiar; i++)
            {
                for (int j = 0; j < ((ITablica)klocek).Rozmiar; j++)
                {
                    if (temp[j, i] != 0)
                    {
                        wysokoscUsuwania = klocek.poprzedniRogTablicyY + j;
                        if(wysokoscUsuwania >= 0)
                        {
                            Console.SetCursorPosition((klocek.poprzedniRogTablicyX + i + 1) * 2, wysokoscUsuwania);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("  ");
                        }
                    }
                }
                Console.SetCursorPosition(0, plansza.Wysokosc + 1 - plansza.IleLiniiNiewidocznych);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static void WyswietlDodatkoweInformacje(Plansza plansza)
        {
            for (int i = 0; i < NapisTetris.napisTetris.GetLength(0); i++)
            {
                Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, i);
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
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 1);
            Console.Write("Punkty: 0");
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 4);
            Console.Write("Sterowanie: ");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 5);
            Console.WriteLine("Lewo - ←");
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 6);
            Console.WriteLine("Prawo - →");
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 7);
            Console.WriteLine("Dol - ↓");
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 8);
            Console.WriteLine("Obrot w prawo - ↑ lub X");
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 9);
            Console.WriteLine("Obrot w lewo - Z");
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 11);
            Console.WriteLine("Wcisnij dowolny klawisz aby zaczac");

        }

        public static void AktualizacjaPunktow(Plansza plansza, int punkty)
        {
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2 + 8, NapisTetris.napisTetris.GetLength(0) + 1);
            Console.Write(punkty);
        }

        public static void UsunNapisDowolnyKlawisz(Plansza plansza)
        {
            Console.SetCursorPosition((plansza.Szerokosc + 5) * 2, NapisTetris.napisTetris.GetLength(0) + 11);
            Console.WriteLine("                                  ");
        }

        public static void WyswietlKoniecGry(Plansza plansza)
        {
            Console.SetCursorPosition(0, 0);
            string napisKoncaGry = "Game Over!";
            Console.SetCursorPosition((2 + plansza.Szerokosc - napisKoncaGry.Length / 2), (plansza.Wysokosc - plansza.IleLiniiNiewidocznych -1) / 2);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(napisKoncaGry);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }

        public static void PrzejscieKoniecGry(Plansza plansza)
        {
            //od dolu
            Console.BackgroundColor = ConsoleColor.Gray;
            for (int i = plansza.Wysokosc - 1 - plansza.IleLiniiNiewidocznych; i >= 0; i--)
            {
                Console.SetCursorPosition(2, i);
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(50);
            }
            //od gory
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < plansza.Wysokosc - plansza.IleLiniiNiewidocznych; i++)
            {
                Console.SetCursorPosition(2, i);
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(50);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WyswietlUsuwaneLinie(Plansza plansza, List<int> indeksy)
        {
            for (int i = 0; i < indeksy.Count; i++)
            {
                Console.SetCursorPosition(2, indeksy[i] - plansza.IleLiniiNiewidocznych);
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            System.Threading.Thread.Sleep(250);
        }
    }
}
