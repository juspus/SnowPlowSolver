﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Interfaces
{
    public interface IIndividual
    {
        double Score { get; }
        IList<ILine> Path { get; }
        double CalculateScore();
        void Mutate();
        IIndividual Cross(IIndividual partner);
    }
}