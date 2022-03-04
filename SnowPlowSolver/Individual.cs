using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal struct Individual : IIndividual
    {
        private readonly IGeneticAlgorithm _GeneticAlgorithm;
        public double Score { get; private set; }

        public IList<ILine> Path { get; private set; }

        public Individual(IGeneticAlgorithm geneticAlgorithm, IList<ILine> path)
        {
            _GeneticAlgorithm = geneticAlgorithm;
            Path = path.ToList();
            Score = _GeneticAlgorithm.FitnessFunction.CalculateScore(Path);
        }
        public double CalculateScore()
        {
            Score = _GeneticAlgorithm.FitnessFunction.CalculateScore(Path);
            return Score;
        }
        public void Mutate()
        {
            Path = _GeneticAlgorithm.Mutation.Mutate(Path);
        }
        public IIndividual Cross(IIndividual partner)
        {
            return new Individual(_GeneticAlgorithm, _GeneticAlgorithm.Crossover.Perform(this.Path, partner.Path));
        }
    }
}
