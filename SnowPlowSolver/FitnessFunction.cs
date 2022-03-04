using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    public class FitnessFunction : IFitnessFunction
    {
        private const double ANGLE_CHANGE_PENALTY = 300;
        public double CalculateScore(IEnumerable<ILine> path)
        {
            double score = 0;

            for(var i =1; i < path.Count(); i++)
            {
                var firstLine = path.ElementAt(i - 1);
                var secondLine = path.ElementAt(i);
                var linesDistance = DistanceBetweenLines(firstLine, secondLine);
                score -= linesDistance.Item1;
                score -= AngleChangeBetweeenLines(firstLine, secondLine) * ANGLE_CHANGE_PENALTY;
                if(linesDistance.Item2)
                {
                    secondLine.Reverse();
                }
            }
            return score;
        }

        private (double, bool) DistanceBetweenLines(ILine first, ILine second)
        {
            var deltaESX = second.StartPoint.X - first.EndPoint.X;
            var deltaESY = second.StartPoint.Y - first.EndPoint.Y;

            var deltaEEX = second.EndPoint.X - first.EndPoint.X;
            var deltaEEY = second.StartPoint.Y - first.EndPoint.Y;

            var squareDistanceEE = deltaEEX * deltaEEX + deltaEEY * deltaEEY;
            var squareDistanceES = deltaESX * deltaESX + deltaESY * deltaESY;

            var squareDistance = squareDistanceES;
            var reverseLine = false;
            if (squareDistanceES > squareDistanceEE)
            {
                squareDistance = squareDistanceES;
                reverseLine = true;
            }
            return (Math.Sqrt(squareDistance), reverseLine);
        }

        public double AngleChangeBetweeenLines(ILine first, ILine second)
        {
            var a = first.Direction;
            var b = second.Direction;

            double theta1 = Math.Atan2(a.Y, a.X);
            double theta2 = Math.Atan2(b.Y, b.X);
            
            double diff = Math.Abs(theta1 - theta2) * 180 / Math.PI;
            double angleDelta = Math.Min(diff, Math.Abs(180 - diff));
            return angleDelta;
        }
    }
}
