using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal class GA : IGeneticAlgorithm, IOptimizationAlgorithm
    {
        private int _Epochs;
        private int _PopulationSize;
        private IEnumerable<ILine>? _Lines;

        public IFitnessFunction FitnessFunction => throw new NotImplementedException();

        IMutation IGeneticAlgorithm.Mutation => throw new NotImplementedException();

        ICrossover IGeneticAlgorithm.Crossover => throw new NotImplementedException();

        public void Evolution()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILine> OptimizePath()
        {
            throw new NotImplementedException();
        }

        public void SetParameters(int epochs, int populationSize)
        {
            _Epochs = epochs;
            _PopulationSize = populationSize;
        }

        public void SetPathToOptimize(IEnumerable<ILine> lines)
        {
            _Lines = lines;
        }
    }
}
