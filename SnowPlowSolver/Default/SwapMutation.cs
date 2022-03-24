using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Default
{
    internal class SwapMutation : IMutation
    {
        private readonly IRandomizer _randomizer;
        public SwapMutation(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }
        public IList<ILine> Mutate(IList<ILine> lines)
        {
            var randomLineFirst = _randomizer.GenerateBetween(0, lines.Count);
            int randomLineSecond = _randomizer.GenerateBetween(0, lines.Count);
            while (randomLineSecond == randomLineFirst)
            {
                randomLineSecond = _randomizer.GenerateBetween(0, lines.Count);
            }
            var firstLine = lines[randomLineFirst];
            lines[randomLineFirst] = lines[randomLineSecond];
            lines[randomLineSecond] = firstLine;
            return lines;
        }

    }
}
