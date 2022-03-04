using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    internal interface IIndividual
    {
        double Score { get; }
        IEnumerable<ILine> Path { get; }
        double CalculateScore();
        void Mutate();
        IIndividual Cross(IIndividual partner);
    }
}
