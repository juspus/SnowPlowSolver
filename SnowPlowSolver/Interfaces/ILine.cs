using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    /// <summary>
    /// Implementation must be Struct
    /// </summary>
    public interface ILine : IEquatable<ILine>
    {
        /// <summary>
        /// Start of line point.
        /// </summary>
        IPoint StartPoint { get; }
        /// <summary>
        /// End of line point.
        /// </summary>
        IPoint EndPoint { get; }
        /// <summary>
        /// Reverses the line swapping the start and end. Recalculates the direction.
        /// </summary>
        void Reverse();
        /// <summary>
        /// Set to true on reverse.
        /// </summary>
        bool Reversed { get; }
        /// <summary>
        /// Identification of line.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Direction of line.
        /// </summary>
        Vector2 Direction { get; }
    }
}
