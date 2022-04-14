using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Interface for survival selection.
    /// </summary>
    public interface ISurvivorSelection
    {
        /// <summary>
        /// Select which individuals pass to next epoch.
        /// </summary>
        /// <param name="firstGen">Old generation.</param>
        /// <param name="secondGen">New Generation.</param>
        /// <returns>Survived generation.</returns>
        IEnumerable<IIndividual> GetSurvivors(IEnumerable<IIndividual> firstGen, IEnumerable<IIndividual> secondGen);
    }
}
