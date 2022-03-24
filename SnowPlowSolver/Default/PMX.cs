using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver.Default
{
    internal class PMX : ICrossover
    {
        private readonly IRandomizer _randomizer;
        private double CrossoverRate;
        public PMX(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public void SetCrossoverRate(double crossRate)
        {
            CrossoverRate = crossRate;
        }

        public IList<ILine> Perform(IList<ILine> mother, IList<ILine> father)
        {
            if (!CrossoverIsPerformed())
            {
                return mother;
            }

            var elementsCount = mother.Count();
            //Sukuriamas vaiko masyvas
            ILine[] offspring = new ILine[elementsCount];
            //Gaunamos pradžios ir pabaigos aleles
            var Allele = new Allele(_randomizer, elementsCount);

            CopySwath(Allele, offspring, mother);
            FillSwathDifference(Allele, offspring, mother, father);
            FillMissing(offspring, father);
            return offspring;
        }

        public int FindElementInAnotherParent(IList<ILine> mama, IList<ILine> papa, int idx)
        {
            var el = papa[idx];
            var index = mama.IndexOf(el);
            return index;
        }

        private bool CrossoverIsPerformed()
        {
            return _randomizer.GeneratePercent() < CrossoverRate;
        }

        private IList<ILine> CopySwath(Allele allele, ILine[] offspring, IList<ILine> mama)
        {
            for (var i = allele.Start; i < allele.Stop; i++)
            {
                offspring[i] = mama[i];
            }
            return offspring;
        }

        private void FillSwathDifference(Allele allele, ILine[] offspring, IList<ILine> mama, IList<ILine> papa)
        {
            for (var i = allele.Start; i < allele.Stop; i++)
            {
                if (!offspring.Where(x => papa[i].Equals(x)).Any())
                {
                    offspring[FindPlaceToCopy(offspring, mama, papa, i)] = papa[i];
                }
            }
        }

        private void FillMissing(ILine[] offspring, IList<ILine> papa)
        {
            for (var i = 0; i < offspring.Length; i++)
            {
                if (offspring[i] == null)
                {
                    offspring[i] = papa[i];
                }
            }
        }

        private int FindPlaceToCopy(IList<ILine> offspring, IList<ILine> mama, IList<ILine> papa, int id)
        {
            var newEle = papa[FindElementInAnotherParent(papa, mama, id)];
            var newIdx = papa.IndexOf(newEle);
            if (offspring.Where(x => mama[newIdx].Equals(x)).Any())
            {
                return FindPlaceToCopy(offspring, mama, papa, newIdx);
            }
            return newIdx;
        }
    }

    internal class Allele
    {
        public int Start { get; }
        public int Stop { get; }
        public Allele(IRandomizer randomizer, int elementsCount)
        {
            //Pradinė ir galinė kopijuojamo genų ruožo alelės
            Start = randomizer.GenerateBetween(0, elementsCount);
            Stop = randomizer.GenerateBetween(Start, elementsCount);
        }
    }
}
