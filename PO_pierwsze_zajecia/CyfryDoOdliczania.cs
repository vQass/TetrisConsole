using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class CyfryDoOdliczania
    {
        public static Dictionary<int, int[,]> cyfry = new Dictionary<int, int[,]>();
        public const int ROZMIAR_CYFRY = 5;
        public static void InicjalizacjaTablicyCyfr()
        {
            cyfry.Add(1, new int[CyfryDoOdliczania.ROZMIAR_CYFRY, CyfryDoOdliczania.ROZMIAR_CYFRY]
            {
                {0, 1, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 1, 1, 1, 0}
            });

            cyfry.Add(2, new int[CyfryDoOdliczania.ROZMIAR_CYFRY, CyfryDoOdliczania.ROZMIAR_CYFRY]
            {
                {0, 2, 2, 2, 0},
                {0, 0, 0, 2, 0},
                {0, 2, 2, 2, 0},
                {0, 2, 0, 0, 0},
                {0, 2, 2, 2, 0}
            });

            cyfry.Add(3, new int[CyfryDoOdliczania.ROZMIAR_CYFRY, CyfryDoOdliczania.ROZMIAR_CYFRY]
            {
                {0, 3, 3, 3, 0},
                {0, 0, 0, 3, 0},
                {0, 0, 3, 3, 0},
                {0, 0, 0, 3, 0},
                {0, 3, 3, 3, 0}
            });
        }
    }
}
