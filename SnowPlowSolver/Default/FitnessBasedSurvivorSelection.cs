﻿using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Default
{
    internal class FitnessBasedSurvivorSelection : ISurvivorSelection
    {
        private int eliteAmount = 5;
        public void SetEliteNumber(int amount)
        {
            eliteAmount = amount;
        }
        public IEnumerable<IIndividual> GetSurvivors(IEnumerable<IIndividual> firstGen, IEnumerable<IIndividual> secondGen)
        {
            firstGen = firstGen.OrderBy(x => x.Score);
            List<IIndividual> nextGen = firstGen.Take(eliteAmount).ToList();
            secondGen = secondGen.OrderBy(x => x.Score);
            nextGen.AddRange(secondGen.Take(secondGen.Count() - eliteAmount).ToList());
            return nextGen;
        }
    }
}
