using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class KlocekS : Tetromino, ITablica
    {
        public Dictionary<Pozycja, int[,]> Tab { get; } = new Dictionary<Pozycja, int[,]>();
        public int Rozmiar { get; }
        public KlocekS(Plansza plansza)
        {
            Tab.Add(Pozycja.Pierwsza, new int[,]
            {
                {0, 2, 2},
                {2, 2, 0},
                {0, 0, 0}
            });

            Tab.Add(Pozycja.Druga, new int[,]
            {
                {2, 0, 0},
                {2, 2, 0},
                {0, 2, 0}
            });

            Tab.Add(Pozycja.Trzecia, new int[,]
            {
                {0, 0, 0},
                {0, 2, 2},
                {2, 2, 0}
            });

            Tab.Add(Pozycja.Czwarta, new int[,]
            {
                {0, 2, 0},
                {0, 2, 2},
                {0, 0, 2}
            });
            int[,] temp;
            Tab.TryGetValue(Pozycja.Pierwsza, out temp);
            Rozmiar = temp.GetLength(0);
            RogTablicyX = plansza.tab.GetLength(0) / 2 - Rozmiar / 2;
        }
    }

}
