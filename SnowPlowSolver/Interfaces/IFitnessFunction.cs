using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for fitness function.
    /// </summary>
    public interface IFitnessFunction
    {
        /// <summary>
        /// Calculates score of the provided path. The higher the score the better the path.
        /// </summary>
        /// <param name="path">Path to calculate the score of.</param>
        /// <returns>Score of the calculated path. The higher the score, the better the path.</returns>
        double CalculateScore(IEnumerable<ILine> path);
    }
}
