using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    public interface IFitnessFunction
    {
        double CalculateScore(IEnumerable<ILine> path);
    }
}
