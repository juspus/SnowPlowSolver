using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal interface IMutation
    {
        IList<ILine> Mutate(IList<ILine> lines);
    }
}
