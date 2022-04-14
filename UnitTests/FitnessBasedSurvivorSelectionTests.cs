using SnowPlowSolver.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using SnowPlowSolver.Interfaces;
using Moq;

namespace UnitTests
{
    public class FitnessBasedSurvivorSelectionTests
    {
        [Fact]
        public void SelectSurvivors()
        {
            FitnessBasedSurvivorSelection selection = new FitnessBasedSurvivorSelection();
            var p1 = GenerateGeneration();
            var p2 = GenerateGeneration();

            var survivors = selection.GetSurvivors(p1, p2);

            survivors.Should().Contain(p1.Take(5));
            survivors.Should().Contain(p2.Take(5));
            survivors.Count().Should().Be(10);
        }

        public IEnumerable<IIndividual> GenerateGeneration()
        {
            var population = new List<IIndividual>();
            
            for (var i = 0; i<10; i++)
            {
                var inv = new Mock<IIndividual>();
                inv.Name = i.ToString();
                inv.SetupGet(x => x.Score).Returns(-i);
                population.Add(inv.Object);
            }
            return population;
        }
    }
}
