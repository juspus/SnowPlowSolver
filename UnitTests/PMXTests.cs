using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using System.Numerics;
using SnowPlowSolver.Interfaces;
using SnowPlowSolver.Default;

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
            randomizerMock.Setup(r => r.GenerateBetween(0, 10)).Returns(3);
            randomizerMock.Setup(r => r.GenerateBetween(3, 10)).Returns(6);

            PMX pmx = new PMX(randomizerMock.Object);
            pmx.SetCrossoverRate(0.1);

            var mother = GenerateMother();
            var father = GenerateFather();
            var offspring = pmx.Perform(mother, father);

            offspring.Should().BeEquivalentTo(Expected());
        }


        public IList<ILine> GenerateMother()
        {
            var lines = new List<ILine>();
            lines.Add(new Line(0));
            lines.Add(new Line(1));
            lines.Add(new Line(2));
            lines.Add(new Line(3));//
            lines.Add(new Line(4));//
            lines.Add(new Line(5));//
            lines.Add(new Line(6));
            lines.Add(new Line(7));
            lines.Add(new Line(8));
            lines.Add(new Line(9));
            return lines;
        }

        public IList<ILine> GenerateFather()
        {
            var lines = new List<ILine>();
            lines.Add(new Line(4));
            lines.Add(new Line(1));
            lines.Add(new Line(7));
            lines.Add(new Line(3));//
            lines.Add(new Line(5));//
            lines.Add(new Line(2));//
            lines.Add(new Line(6));
            lines.Add(new Line(8));
            lines.Add(new Line(9));
            lines.Add(new Line(0));
            return lines;
        }

        public ILine[] Expected()
        {
            return new ILine[]
            {
                new Line(2),
                new Line(1),
                new Line(7),
                new Line(3),
                new Line(4),
                new Line(5),
                new Line(6),
                new Line(8),
                new Line(9),
                new Line(0)
            };
        }

        public class Line : ILine
        {
            public IPoint StartPoint { get => null; }

            public IPoint EndPoint { get => null; }

            public bool Reversed { get => false; }

            public int Id { get; }

            public Vector2 Direction { get => new Vector2(0,0); }

            public bool Equals(ILine? other)
            {
                if(other == null)
                {
                    return false;
                }
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
