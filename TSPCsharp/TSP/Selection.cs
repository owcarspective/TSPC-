using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Selection
    {
        Random r;
        
        public Selection(Random _r)
        {
            r = _r;
        }   
        
        public int[][] Tournament(Population p, int k)
        {
            int[][] ret = new int[p.m][];
            for(int i = 0; i < p.m; i++)
            {
                ret[i] = RandTournament(p, k);
            }

            return ret;
        }
        private int[] RandTournament(Population p, int k)
        {
            int[] indexes = new int[k];
            int indexMin = r.Next(p.m);
            int minValue = p.Fitness[indexMin];
            for (int i = 1; i < k; i++)
            {
                int j = r.Next(p.m);
                if(p.Fitness[j] < minValue)
                {
                    indexMin = j;
                    minValue = p.Fitness[indexMin];
                }
            }

            return p.individualsTab[indexMin];
        }


        public int[][] Proportional(Population p)
        {
            int[] tmpFitness = new int[p.m];
            int max = p.Fitness.Max();
            for(int i = 0; i < tmpFitness.Length; i++)
            {
                tmpFitness[i] = max - p.Fitness[i] + 1;
            }

            int[][] ret = new int[p.m][];
            max = tmpFitness.Max();
            for(int i = 0; i < p.m; i++)
            {
                int rand = r.Next(max + 1);
                int sum = 0;
                int j = 0;
                
                while (rand >= sum)
                {
                    sum += tmpFitness[j];
                    j++;
                }
                ret[i] = p.individualsTab[j - 1];
            }

            return ret;
        }
    }
}
