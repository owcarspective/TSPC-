using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Crossover
    {
        Random r;

        public Crossover(Random _r)
        {
            r = _r;
        }

        public int[][] OXCrossover(int[][] population, int crossFactor)
        {
            population.OrderBy(x => r.Next());
            int[][] children = new int[population.Length][];

            for (int i = 0; i < population.Length; i++)
            {

                if (r.Next(100) <= crossFactor)
                {
                    if (i + 1 < population.Length)
                    {
                        int[] child1 = CrossOX(population[i], population[i + 1]);
                        children[i] = child1;
                    }
                    else
                        children[i] = population[i];
                }
                else
                    children[i] = population[i];
            }

            return children;
        }

        private int[] CrossOX(int[] parent1, int[] parent2)
        {
            int sliceID = r.Next(1, parent1.Length - 2);
            int SliceID2 = r.Next(sliceID, parent1.Length - 1);
            int?[] child = new int?[parent1.Length];

            for(int i = sliceID; i <= SliceID2; i++)
            {
                child[i] = parent1[i];
            }

            for(int i = SliceID2 + 1, j = SliceID2 + 1; i != sliceID; j++)
            {
                if (j >= parent2.Length)
                    j = 0;

                if (!(child.Contains(parent2[j])))
                {
                    child[i] = parent2[j];
                    i++;                 
                }

                if (i >= child.Length)
                    i = 0;

            }

            int[] retChild = new int[child.Length];
            for (int i = 0; i < child.Length; i++)
            {
                 retChild[i] = child[i] ?? default(int);
            }

            return retChild;
        }

        private string TabToString(int[] tab)
        {
            string ret = "";
            foreach (int i in tab)
                ret += i + "; ";
            return ret;
        }
    }
}
