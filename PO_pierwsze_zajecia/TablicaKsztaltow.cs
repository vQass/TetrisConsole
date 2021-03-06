using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class TablicaKsztaltow
    {
        public static Dictionary<Pozycja, int[,]> klocki = new Dictionary<Pozycja, int[,]>();

        public static void WypelnijTablice()
        {
            klocki.Add(Pozycja.T1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.T2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.T3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.T4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
            klocki.Add(Pozycja.S1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.S2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.S3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.S4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
            klocki.Add(Pozycja.Z1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.Z2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.Z3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.Z4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
            klocki.Add(Pozycja.J1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.J2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.J3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.J4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
            klocki.Add(Pozycja.L1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.L2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.L3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.L4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
            klocki.Add(Pozycja.I1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.I2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.I3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.I4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
            klocki.Add(Pozycja.O1, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
{
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
});

            klocki.Add(Pozycja.O2, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.O3, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.O4, new int[Klocek.ROZMIAR_BLOKU, Klocek.ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });
        }
    }
}
