using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using SnowPlowSolver;
using FluentAssertions;
using System.Numerics;

namespace UnitTests
{
    public class PMXTests
    {
        [Fact]
        public void PerfromPMXTest()
        {
            var randomizer = new Randomizer();
            Mock<IRandomizer> randomizerMock = new Mock<IRandomizer>();
            randomizerMock.Setup(r => r.GeneratePercent()).Returns(0);
            randomizerMock.Setup(r => r.GenerateBetween(It.IsAny<int>(), It.IsAny<int>())).Returns((int m, int p) => randomizer.GenerateBetween(m,p));

            PMX pmx = new PMX(randomizerMock.Object);
            pmx.SetCrossoverRate(0.1);

            var mother = GenerateMother();
            var father = GenerateFather();
                var offspring = pmx.Perform(mother, father);

        }


        public IEnumerable<ILine> GenerateMother()
        {
            var lines = new List<ILine>();
            lines.Add(new Line(0));
            lines.Add(new Line(1));
            lines.Add(new Line(2));
            lines.Add(new Line(3));
            lines.Add(new Line(4));
            lines.Add(new Line(5));
            lines.Add(new Line(6));
            lines.Add(new Line(7));
            lines.Add(new Line(8));
            lines.Add(new Line(9));
            return lines;
        }

        public IEnumerable<ILine> GenerateFather()
        {
            var lines = new List<ILine>();
            lines.Add(new Line(4));
            lines.Add(new Line(1));
            lines.Add(new Line(7));
            lines.Add(new Line(3));
            lines.Add(new Line(5));
            lines.Add(new Line(2));
            lines.Add(new Line(6));
            lines.Add(new Line(8));
            lines.Add(new Line(9));
            lines.Add(new Line(0));
            return lines;
        }

        public class Line : ILine
        {
            public IPoint StartPoint => throw new NotImplementedException();

            public IPoint EndPoint => throw new NotImplementedException();

            public bool Reversed => throw new NotImplementedException();

            public int Id { get; }

            public Vector2 Direction => throw new NotImplementedException();

            public bool Equals(ILine? other)
            {
                return Id == other.Id;
            }

            public void Reverse()
            {
                throw new NotImplementedException();
            }
            public Line(int id)
            {
                Id = id;
            }
        }
    }
}
