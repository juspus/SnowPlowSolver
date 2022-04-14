using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for optimization algorithm.
    /// </summary>
    public interface IOptimizationAlgorithm
    {
        /// <summary>
        /// Optimizes provided path.
        /// </summary>
        /// <param name="lines">Path to optimize.</param>
        /// <returns>Optimized path.</returns>
        IEnumerable<ILine> OptimizePath(IEnumerable<ILine> lines);
    }
}
