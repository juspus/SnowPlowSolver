using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    public interface ISurvivorSelection
    {
        IEnumerable<IIndividual> GetSurvivors(IEnumerable<IIndividual> firstGen, IEnumerable<IIndividual> secondGen);
    }
}
