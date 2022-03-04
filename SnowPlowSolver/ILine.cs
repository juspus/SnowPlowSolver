using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    /// <summary>
    /// Implementation must be Struct
    /// </summary>
    public interface ILine: IEquatable<ILine>
    {
        IPoint StartPoint { get; }
        IPoint EndPoint { get; }
        void Reverse();
        bool Reversed { get; }
        int Id { get; }
        Vector2 Direction { get; }
    }
}
