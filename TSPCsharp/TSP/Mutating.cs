using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Mutating
    {
        private Random r;

        public Mutating(Random _r)
        {
            r = _r;
        }

        public int[][] Mutations(int[][] population, int z)
        {
            for (int i = 0; i < population.Length; i++)
            {
                int rand = r.Next(100);
                if (rand >= 0 && rand <= z)
                {
                    int[] child = Mutation(population[i]);
                    population[i] = child;
                }
                
            }

            return population;
        }

        private int[] Mutation(int[] child)
        {

            int sliceID = r.Next(child.Length - 1);
            int sliceID2 = r.Next(sliceID, child.Length);
            int[] tmp = new int[sliceID2 - sliceID + 1];
                
            for (int i = 0, j = sliceID2; i < tmp.Length; i++, j--)
            {
                tmp[i] = child[j];
            }

            for (int i = sliceID, j = 0; i <= sliceID2; i++, j++)
            {
                child[i] = tmp[j];
            }

            return child;

        }
    }    
}