using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class PlanszaDoUsuniecia
    {
        public static int[,] tab = new int[,]
{
        {0,1,1,1,1,1,1,1,1,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {1,1,1,1,1,1,1,1,1,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {1,1,1,1,1,1,0,0,1,1 },
        {1,1,1,1,1,0,0,0,1,1 },
        {1,1,1,1,1,1,0,1,1,1 }
};

        public static void NadpiszPlansze(Plansza plansza)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    plansza.tab[j, i] = PlanszaDoUsuniecia.tab[i, j];
                }
            }
        }
    }
}
