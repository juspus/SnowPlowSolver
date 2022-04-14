using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for parents crossover.
    /// </summary>
    public interface ICrossover
    {
        /// <summary>
        /// Perform crossover between 2 individuals.
        /// </summary>
        /// <param name="mother">First individual in crossover.</param>
        /// <param name="father">Second individual in crossover.</param>
        /// <returns>Product of crossover - single individual path.</returns>
        IList<ILine> Perform(IList<ILine> mother, IList<ILine> father);
    }
}
