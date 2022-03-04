using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    public class Randomizer : IRandomizer
    {
        Random rng = new Random();
        public double GeneratePercent()
        {
            return rng.NextDouble();
        }

        public int GenerateBetween(int start, int end)
        {
            return rng.Next(start, end);
        }
    }
}
