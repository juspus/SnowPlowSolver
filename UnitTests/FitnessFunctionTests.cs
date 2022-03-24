using Xunit;
using Moq;
using FluentAssertions;
using SnowPlowSolver.Interfaces;
using SnowPlowSolver.Default;

namespace UnitTests
{
    public class FitnessFunctionTests
    {
        [Theory]
        [InlineData(0,0,0,0,0)]
        [InlineData(1, 0, 1, 0, 0)]
        [InlineData(0, 1, 1, 0, 90)]
        [InlineData(1, 0, 0, 1, 90)]
        [InlineData(-1, -1, 1, 1, 0)]
        [InlineData(-1, -1, 1, 0, 45)]
        [InlineData(1, 1, 1, 0, 45)]
        [InlineData(50, 50, 1, 0, 45)]
        public void AngleChangeTest(
            double fx, double fy,
            double ex, double ey,
            double expected)
        {
            Mock<ILine> firstLine=new Mock<ILine>();
            firstLine.SetupGet(x => x.Direction).Returns(new System.Numerics.Vector2((float)fx, (float)fy));
            Mock<ILine> secLine = new Mock<ILine>();
            secLine.SetupGet(x => x.Direction).Returns(new System.Numerics.Vector2((float)ex, (float)ey));
            var fitnessFunction = new FitnessFunction();

            var actual = fitnessFunction.AngleChangeBetweeenLines(firstLine.Object, secLine.Object);

            actual.Should().Be(expected);

        }
    }
}