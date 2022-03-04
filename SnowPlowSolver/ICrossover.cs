using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal interface ICrossover
    {
        IEnumerable<ILine> Perform(IEnumerable<ILine> mother, IEnumerable<ILine> father);
    }
}
