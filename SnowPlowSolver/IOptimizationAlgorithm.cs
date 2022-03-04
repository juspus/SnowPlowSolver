using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    public interface IOptimizationAlgorithm
    {
        IEnumerable<ILine> OptimizePath();
        void SetPathToOptimize(IEnumerable<ILine> lines);
    }
}
