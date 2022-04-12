using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowProblem
{
    internal static class IPointExtension
    {
        public static netDxf.Vector2 ConvertToVector(this IPoint pt)
        {
            return new netDxf.Vector2(pt.X, pt.Y);
        }
    }
}
