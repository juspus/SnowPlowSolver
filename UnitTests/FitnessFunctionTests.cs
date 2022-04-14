using Xunit;
using Moq;
using FluentAssertions;
using SnowPlowSolver.Interfaces;
using SnowPlowSolver.Default;
using System.Collections.Generic;

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

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 0, 1, 0, 0)]
        [InlineData(0, 1, 1, 0, -27001.41)]
        [InlineData(1, 0, 0, 1, -27001.41)]
        [InlineData(-1, -1, 1, 1, -2.83)]
        [InlineData(-1, -1, 1, 0, -13502.23)]
        [InlineData(1, 1, 1, 0, -13501)]
        [InlineData(50, 50, 1, 0, -13570.01)]
        public void CalculateScoreTests(
            double fx, double fy,
            double ex, double ey,
            double expected)
        {
            Mock<ILine> firstLine = new Mock<ILine>();
            firstLine.SetupGet(x => x.StartPoint.X).Returns((float)fx);
            firstLine.SetupGet(x => x.StartPoint.Y).Returns((float)fy);
            firstLine.SetupGet(x => x.EndPoint.X).Returns((float)fx);
            firstLine.SetupGet(x => x.EndPoint.Y).Returns((float)fy);
            firstLine.SetupGet(x => x.Direction).Returns(new System.Numerics.Vector2((float)fx, (float)fy));
            Mock<ILine> secLine = new Mock<ILine>();
            secLine.SetupGet(x => x.StartPoint.X).Returns((float)ex);
            secLine.SetupGet(x => x.StartPoint.Y).Returns((float)ey);
            secLine.SetupGet(x => x.EndPoint.X).Returns((float)ex);
            secLine.SetupGet(x => x.EndPoint.Y).Returns((float)ey);
            secLine.SetupGet(x => x.Direction).Returns(new System.Numerics.Vector2((float)ex, (float)ey));
            var fitnessFunction = new FitnessFunction();
            var path = new List<ILine>()
            { firstLine.Object, secLine.Object};


            var actual = fitnessFunction.CalculateScore(path);

            actual.Should().BeApproximately(expected, 0.01);
        }
    }
}