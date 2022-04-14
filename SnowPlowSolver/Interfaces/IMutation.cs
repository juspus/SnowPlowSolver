using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for muetation.
    /// </summary>
    public interface IMutation
    {
        /// <summary>
        /// Changes provided path.
        /// </summary>
        /// <param name="lines">Path to mutate.</param>
        /// <returns>Mutated path.</returns>
        IList<ILine> Mutate(IList<ILine> lines);
    }
}
