using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    public interface IWallKicks
    {
        Dictionary<Pozycja, int[,]> ObrotWLewo { get; }
        Dictionary<Pozycja, int[,]> ObrotWPrawo { get; }
    }
}
