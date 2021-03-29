using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class WallKicksNonIShape : IWallKicks
    {
        public Dictionary<Pozycja, int[,]> ObrotWLewo { get; } = new Dictionary<Pozycja, int[,]>();
        public Dictionary<Pozycja, int[,]> ObrotWPrawo { get; } = new Dictionary<Pozycja, int[,]>();

        public WallKicksNonIShape()
        {
            // pozycja == nastepnaPozycja czyli ta po wykonaniu obrotu
            ObrotWLewo.Add(Pozycja.Pierwsza, new int[,]
            {
                {0, 0},
                {1, 0},
                {1, 1},
                {0, -2},
                {1, -2}
            });
            ObrotWLewo.Add(Pozycja.Druga, new int[,]
            {
                {0, 0},
                {-1, 0},
                {-1, -1},
                {0, 2},
                {-1, 2}
            });
            ObrotWLewo.Add(Pozycja.Trzecia, new int[,]
            {
                {0, 0},
                {-1, 0},
                {-1, 1},
                {0, -2},
                {-1, -2}
            });
            ObrotWLewo.Add(Pozycja.Czwarta, new int[,]
            {
                {0, 0},
                {1, 0},
                {1, -1},
                {0, 2},
                {1, 2}
            });

            ObrotWPrawo.Add(Pozycja.Pierwsza, new int[,]
            {
                {0, 0},
                {-1, 0},
                {-1, 1},
                {0, -2},
                {-1, -2}
            });
            ObrotWPrawo.Add(Pozycja.Druga, new int[,]
            {
                {0, 0},
                {-1, 0},
                {-1, -1},
                {0, 2},
                {-1, 2}
            });
            ObrotWPrawo.Add(Pozycja.Trzecia, new int[,]
            {
                {0, 0},
                {1, 0},
                {1, 1},
                {0, -2},
                {1, -2}
            });
            ObrotWPrawo.Add(Pozycja.Czwarta, new int[,]
            {
                {0, 0},
                {1, 0},
                {1, -1},
                {0, 2},
                {1, 2}
            });
        }
    }
}
