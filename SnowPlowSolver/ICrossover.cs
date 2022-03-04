using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal interface ICrossover
    {
        IList<ILine> Perform(IList<ILine> mother, IList<ILine> father);
    }
}
