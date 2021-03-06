using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class Plansza
    {
        public int[,] tab = new int[1,1];
        public Plansza(int szerokosc, int wysokosc)
        {
            tab = new int[szerokosc, wysokosc];
        }
    }
}
