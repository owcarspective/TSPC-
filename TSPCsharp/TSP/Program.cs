using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{    
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            string path = @".\a280.txt";
            int size = 50;
            int elite = 4;
            int mutChance = 40;
            int crossFactor = 70;
            string location = @".\a280_wynik.txt";
            

            Distances d = new Distances(path);
            Population p = new Population(size, d, r);
            Selection s = new Selection(r);
            Mutating mut = new Mutating(r);
            int min = p.Fitness.Min();
            int lastImpr = 0;

            Console.WriteLine(min);
            Crossover crossover = new Crossover(r);

            int[] route = new int[p.individualsTab[0].Length];


            int q = 0;

            do
            {
                while (!Console.KeyAvailable)
                {
                    int[][] tournamentTab = s.Tournament(p, elite);
                    int[][] children1 = crossover.OXCrossover(tournamentTab, crossFactor);
                    int[][] children2 = mut.Mutations(children1, mutChance);
                    p.individualsTab = children2;
                    p.Evaluate(d);

                    if (p.Fitness.Min() < min)
                    {
                        min = p.Fitness.Min();
                        for (int i = 0; i < p.Fitness.Length; i++)
                        {
                            if (p.Fitness[i] == min)
                            {
                                route = p.individualsTab[i];
                                break;
                            }
                        }
                        lastImpr = q;
                        Console.WriteLine("Generation: {0} \t Min: {1}", q, min);
                    }

                    
                    q++;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);



            Console.WriteLine("\n\n");
            Console.WriteLine("Generation: {0}  Minimal: {1}", q, min);
            Show(route);
            Write(route, min, location);


            Console.ReadKey();

        }

        public static void Show(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");                               
            }
        }

        public static void Write(int[] path, int min, string loc)
        {
            using (StreamWriter sw = new StreamWriter(loc, true))
            {
                string s = "";
                for(int i = 0; i < path.Length; i++)
                {
                    if (i > 0)
                        s += "-" + path[i];
                    else
                        s += path[i];
                }
                s += " " + min;
                sw.WriteLine(s);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
