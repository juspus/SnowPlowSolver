using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    public interface IOptimizationAlgorithm
    {
        IEnumerable<ILine> OptimizePath(IEnumerable<ILine> lines);
    }
}
