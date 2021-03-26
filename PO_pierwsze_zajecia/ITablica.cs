using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    public interface ITablica
    {
        Dictionary<Pozycja, int[,]> Tab { get; }
        int Rozmiar { get; }
    }
}
