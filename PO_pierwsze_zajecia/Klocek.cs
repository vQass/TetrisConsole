using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PO_pierwsze_zajecia
{
    enum Pozycja
    {
        T1,T2,T3,T4,S1,S2,S3,S4,Z1,Z2,Z3,Z4,J1,J2,J3,J4,L1,L2,L3,L4,I1,I2,I3,I4,O1,O2,O3,O4
    }

    class Klocek
    {
        public const int ROZMIAR_BLOKU = 4;   // rozmiar tablic blokow
        private Pozycja _pozycja = Pozycja.T1;  
        public Pozycja poprzedniaPozycja = Pozycja.T1;   
        private int _rogTablicyX = 0;   
        private int _rogTablicyY = 0;   
        public int poprzedniRogTablicyX = 0;
        public int poprzedniRogTablicyY = 0;
        public Dictionary<Pozycja, int[,]> klocki = new Dictionary<Pozycja, int[,]>();
        public Klocek(Plansza plansza)
        {
            RogTablicyX = plansza.tab.GetLength(0) / 2 - Klocek.ROZMIAR_BLOKU / 2;
            poprzedniRogTablicyX = plansza.tab.GetLength(0) / 2 - Klocek.ROZMIAR_BLOKU / 2;

            klocki.Add(Pozycja.T1, new int[ROZMIAR_BLOKU, ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0}
            });

            klocki.Add(Pozycja.T2, new int[ROZMIAR_BLOKU, ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0}
            });

            klocki.Add(Pozycja.T3, new int[ROZMIAR_BLOKU, ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 0},
                {1, 1, 1, 0}
            });

            klocki.Add(Pozycja.T4, new int[ROZMIAR_BLOKU, ROZMIAR_BLOKU]
            {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0}
            });

        }

        public Pozycja Pozycja
        {
            get => _pozycja;

            set
            {
                poprzedniaPozycja = _pozycja; 
                poprzedniRogTablicyX = RogTablicyX;
                poprzedniRogTablicyY = RogTablicyY;
                _pozycja = value;
            }
        }

        public int RogTablicyX
        {
            get => _rogTablicyX;

            set
            {
                poprzedniaPozycja = _pozycja;
                poprzedniRogTablicyX = RogTablicyX;
                poprzedniRogTablicyY = RogTablicyY;
                _rogTablicyX = value;
            }
        }

        public int RogTablicyY
        {
            get => _rogTablicyY;

            set
            {
                poprzedniaPozycja = _pozycja;
                poprzedniRogTablicyX = RogTablicyX;
                poprzedniRogTablicyY = RogTablicyY;
                _rogTablicyY = value;
            }
        }   
    }
}
