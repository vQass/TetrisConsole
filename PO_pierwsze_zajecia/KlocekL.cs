using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class KlocekL : Tetromino, ITablica
    {
        public Dictionary<Pozycja, int[,]> Tab { get; } = new Dictionary<Pozycja, int[,]>();
        public int Rozmiar { get; }
        public KlocekL(Plansza plansza)
        {
            Tab.Add(Pozycja.Pierwsza, new int[,]
            {
                {0, 0, 5},
                {5, 5, 5},
                {0, 0, 0}
            });

            Tab.Add(Pozycja.Druga, new int[,]
            {
                {0, 5, 0},
                {0, 5, 0},
                {0, 5, 5}
            });

            Tab.Add(Pozycja.Trzecia, new int[,]
            {
                {0, 0, 0},
                {5, 5, 5},
                {5, 0, 0}
            });

            Tab.Add(Pozycja.Czwarta, new int[,]
            {

                {5, 5, 0},
                {0, 5, 0},
                {0, 5, 0}
            });
            int[,] temp;
            Tab.TryGetValue(Pozycja.Pierwsza, out temp);
            Rozmiar = temp.GetLength(0);
            RogTablicyX = plansza.tab.GetLength(0) / 2 - Rozmiar / 2;
        }
    }
}
