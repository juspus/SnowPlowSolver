using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal class IndividualFactory
    {
        private readonly IGeneticAlgorithm _GeneticAlgorithm;
        public IndividualFactory(IGeneticAlgorithm geneticAlgorithm)
        {
            _GeneticAlgorithm = geneticAlgorithm;
        }

        public IIndividual CreateIndividual(IEnumerable<ILine> Path)
        {
            var individual = new Individual(_GeneticAlgorithm, Path);
            return individual;
        }
    }
}
