using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for individual in genetic algorithm.
    /// </summary>
    public interface IIndividual
    {
        /// <summary>
        /// Score of the path in the individual.
        /// </summary>
        double Score { get; }
        /// <summary>
        /// Path of the individual.
        /// </summary>
        IList<ILine> Path { get; }
        /// <summary>
        /// Uses the genetic algorithms setup fitness function to calculate the score.
        /// </summary>
        /// <returns>Individual score.</returns>
        double CalculateScore();
        /// <summary>
        /// Uses genetic algorithm setup mutation to mutate individual.
        /// </summary>
        void Mutate();
        /// <summary>
        /// Uses genetic algorithm setup crossover to cross with another individual.
        /// </summary>
        /// <param name="partner">Individual to cross with.</param>
        /// <returns>Product of crossover. Offspring.</returns>
        IIndividual Cross(IIndividual partner);
    }
}
