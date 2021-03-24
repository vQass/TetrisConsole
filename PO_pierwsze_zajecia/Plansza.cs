using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Plansza
    {
        //plansza.tab.GetLength(0) == Szerokosc
        //plansza.tab.GetLength(1) == Wysokosc

        public int Szerokosc { get; }
        public int Wysokosc { get; }
        public int IleLiniiNiewidocznych { get; }

        public int[,] tab;
        public Plansza(int szerokosc, int wysokosc, int linieNiewidoczne)
        {
            Szerokosc = szerokosc;
            Wysokosc = wysokosc;
            IleLiniiNiewidocznych = linieNiewidoczne;
            tab = new int[szerokosc, wysokosc];
            for (int i = 0; i < Wysokosc; i++)
            {
                for (int j = 0; j < Szerokosc; j++)
                {
                    tab[j, i] = 0;
                }
            }
        }
    }
}
