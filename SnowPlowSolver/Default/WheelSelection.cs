using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Default
{
    internal class WheelSelection : ISelection
    {
        private readonly IRandomizer randomizer;

        public WheelSelection(IRandomizer randomizer)
        {
            this.randomizer = randomizer;
        }
        public IIndividual SelectParent(IEnumerable<IIndividual> population)
        {
            var fullfitness = CalculateFitnessSum(population);
            var randomFitness = randomizer.GenerateBetween(0, fullfitness);
            var selectedIndividual = population.Last();

            double sumOfFitness = 0;
            foreach (var populationItem in population)
            {
                sumOfFitness += populationItem.Score;
                if (sumOfFitness > randomFitness)
                {
                    selectedIndividual = populationItem;
                }
            }
            return selectedIndividual;
        }

        private int CalculateFitnessSum(IEnumerable<IIndividual> population)
        {
            return (int)Math.Round(population.Sum(x => x.Score), MidpointRounding.ToPositiveInfinity);
        }
    }
}
