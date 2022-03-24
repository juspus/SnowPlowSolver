using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using static UnitTests.PMXTests;
using FluentAssertions;
using SnowPlowSolver.Interfaces;
using SnowPlowSolver.Default;

namespace UnitTests
{
    public class SwapMutationTest
    {

        [Fact]
        public void MutationTest()
        {
            var randomizerMoq = new Mock<IRandomizer>();
            var path = GeneratePath();
            randomizerMoq.SetupSequence(x => x.GenerateBetween(0, path.Count)).Returns(0).Returns(1);
            SwapMutation mutation = new SwapMutation(randomizerMoq.Object);
            var expectedpath = GenerateExpectedPath();
            var actualPath = mutation.Mutate(path);

            actualPath.Should().BeEquivalentTo(expectedpath);
        }

        public IList<ILine> GeneratePath()
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

        public IList<ILine> GenerateExpectedPath()
        {
            var lines = new List<ILine>();
            lines.Add(new Line(1));
            lines.Add(new Line(0));
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
    }
}
