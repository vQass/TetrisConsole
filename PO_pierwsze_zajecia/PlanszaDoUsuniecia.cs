using System;
using System.Collections.Generic;
using System.Text;

namespace PO_pierwsze_zajecia
{
    class PlanszaDoUsuniecia
    {
        // Testy 1-5 lewo/prawo

        // Tspin prawo test 3
        //public static int[,] tab = new int[,]
        //{
        //{1,1,1,1,1,0,0,1,1,1 },
        //{1,1,1,1,1,0,0,0,1,1 },
        //{1,1,1,1,1,1,0,1,1,1 }
        //};

        // Tspin lewo test 5
        //public static int[,] tab = new int[,]
        //{
        //{0,0,0,0,0,0,1,1,0,0 },
        //{0,0,0,0,0,0,0,1,0,0 },
        //{1,1,1,1,1,1,0,1,1,1 },
        //{1,1,1,1,1,0,0,1,1,1 },
        //{1,1,1,1,1,1,0,1,1,1 }
        //};

        //public static int[,] tab = new int[,]
        //{
        //{1,1,1,1,1,1,1,1,0,0 },
        //{1,1,1,1,1,1,0,0,0,0 },
        //{1,1,1,1,1,1,1,0,0,1 },
        //{1,1,1,1,1,1,1,0,0,1 },
        //{1,1,1,1,1,1,1,0,1,1 }
        //};

        public static int[,] tab = new int[,]
        {

        {1,0,1,0,1,0,0,0,0,0 },
        {1,1,1,1,1,1,1,1,1,1 },
        {0,0,0,1,0,1,0,1,0,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {0,1,0,1,0,1,0,0,0,0 },
        {1,1,1,1,1,1,1,1,1,1 },
        };

    public static void UzupelnijPlansze(Plansza plansza)
        {
            for (int i = plansza.Wysokosc - 1; i > plansza.Wysokosc - tab.GetLength(0) - 1; i--)
            {
                for (int j = 0; j < plansza.Szerokosc; j++)
                {
                    plansza.tab[j, i] = PlanszaDoUsuniecia.tab[i - (plansza.Wysokosc - tab.GetLength(0)), j];
                }
            }
        }
    }
}
