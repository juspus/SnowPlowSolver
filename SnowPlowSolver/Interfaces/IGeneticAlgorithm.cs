using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    internal interface IGeneticAlgorithm : IOptimizationAlgorithm
    {
        IFitnessFunction FitnessFunction { get; }
        IMutation Mutation { get; }
        ICrossover Crossover { get; }
    }
}
