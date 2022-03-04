using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal interface IGeneticAlgorithm
    {
        IFitnessFunction FitnessFunction { get; }
        IMutation Mutation { get; }
        ICrossover Crossover { get; }
        void SetParameters(int epochs, int populationSize);
        void Evolution();
    }
}
