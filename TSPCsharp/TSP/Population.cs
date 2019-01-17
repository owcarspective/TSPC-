using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Population
    {
        public int[][] individualsTab;
        public int[] Fitness;
        public int m;

        Random r;
        
        public Population(int _m, Distances d, Random _r)
        {
            r = _r;
            m = _m;
            CreatePopulation(m, d.tabDistances.GetLength(0));
            Evaluate(d);
        }

        public Population()
        { }

        public void CreatePopulation(int m, int n)
        {
            individualsTab = new int[m][];
            for(int i = 0; i < m; i++)
            {
                int[] tab = new int[n];
                for(int j = 0; j < n; j++)
                {
                    tab[j] = j;
                }
                tab = tab.OrderBy(x => r.Next()).ToArray();
                individualsTab[i] = tab;
            }
        }

        public void Evaluate(Distances d)
        {
            Fitness = new int[individualsTab.Length];
            for(int i = 0; i < individualsTab.Length; i++)
            {
                int[] tab = individualsTab[i];
                int fitness = 0;

                for (int j = 0; j < tab.Length; j++)
                {
                    if (j + 1 >= tab.Length)
                        fitness += d.GetDistance(tab[j], tab[0]);
                    else
                        fitness += d.GetDistance(tab[j], tab[j + 1]);
                }
                Fitness[i] = fitness;
            }
        }


    }
}
