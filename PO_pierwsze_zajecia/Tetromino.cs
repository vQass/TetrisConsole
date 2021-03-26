using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{

    public enum Pozycja
    {
        Pierwsza, Druga, Trzecia, Czwarta
    }
    class Tetromino
    {
        private Pozycja _pozycja = Pozycja.Pierwsza;
        public Pozycja poprzedniaPozycja = Pozycja.Pierwsza;
        private int _rogTablicyX = 0;
        private int _rogTablicyY = -3;
        public int poprzedniRogTablicyX = 0;
        public int poprzedniRogTablicyY = -3;

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
