using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class KlocekO : Tetromino, ITablica
    {
        public Dictionary<Pozycja, int[,]> Tab { get; } = new Dictionary<Pozycja, int[,]>();
        public int Rozmiar { get; }
        public KlocekO(Plansza plansza)
        {
            Tab.Add(Pozycja.Pierwsza, new int[,]
            {
                {7, 7},
                {7, 7}
            });
            Tab.Add(Pozycja.Druga, new int[,]
            {
                {7, 7},
                {7, 7}
            });
            Tab.Add(Pozycja.Trzecia, new int[,]
            {
                {7, 7},
                {7, 7}
            });
            Tab.Add(Pozycja.Czwarta, new int[,]
            {
                {7, 7},
                {7, 7}
            });
            int[,] temp;
            Tab.TryGetValue(Pozycja.Pierwsza, out temp);
            Rozmiar = temp.GetLength(0);
            RogTablicyX = plansza.tab.GetLength(0) / 2 - Rozmiar / 2;
        }
    }
}
