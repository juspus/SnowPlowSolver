using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for parent selection.
    /// </summary>
    public interface ISelection
    {
        /// <summary>
        /// Select parent from population.
        /// </summary>
        /// <param name="population">Collection of individuals to select from.</param>
        /// <returns>Selected individual.</returns>
        public IIndividual SelectParent(IEnumerable<IIndividual> population);
    }
}
