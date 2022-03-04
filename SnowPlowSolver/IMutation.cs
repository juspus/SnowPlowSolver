using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal interface IMutation
    {
        IEnumerable<ILine> Mutate(IEnumerable<ILine> lines);
    }
}
