using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Distances
    {
        private int[,] _tabDistances;
        public int Length;

        public int[,] tabDistances { get { return _tabDistances; } }

        public Distances(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                int tmpLen = int.Parse(sr.ReadLine().Trim());
                _tabDistances = new int[tmpLen, tmpLen];

                string line = null;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < values.Length; j++)
                    {
                        int val = int.Parse(values[j]);
                        _tabDistances[i, j] = val;
                        _tabDistances[j, i] = val;
                    }
                    i++;
                }
                sr.Close();
                Length = _tabDistances.GetLength(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetDistance(int pointA, int pointB) => _tabDistances[pointA, pointB];
    }
}
