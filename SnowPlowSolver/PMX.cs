using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowSolver
{
    public class PMX : ICrossover
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

        public IEnumerable<ILine> Perform(IEnumerable<ILine> mother, IEnumerable<ILine> father)
        {
            var elementsCount = mother.Count();
            if (_randomizer.GeneratePercent() > CrossoverRate)
            {
                return mother;
            }

            //Sukuriamas vaiko masyvas
            ILine[] offspring = new ILine[elementsCount];

            //Pradinė ir galinė kopijuojamo genų ruožo alelės
            var startAllele =  _randomizer.GenerateBetween(0, elementsCount);
            var stopAllele = _randomizer.GenerateBetween(startAllele, elementsCount);

            //Sukuriamas nesutampančių genų žodynas
            Dictionary<int, ILine> swathDiff = new Dictionary<int, ILine>();

            for (int i = startAllele; i < stopAllele; i++)
            {
                offspring[i] = mother.ElementAt(i);
                swathDiff.Add(i, father.ElementAt(i));
            }

            for (int i = startAllele; i < stopAllele; i++)
            {
                swathDiff = swathDiff.Where(x => x.Value.Id != offspring[i].Id).ToDictionary(x => x.Key, x => x.Value);
            }

            int tryNum = 0;

            if (swathDiff.Any())
            {
                tryNum = swathDiff.First().Key;
            }

            while (0 < swathDiff.Count)
            {
                int idx = Array.FindIndex<ILine>(mother.ToArray(), x => x.Id == father.ElementAt(tryNum).Id);

                if (idx < startAllele || idx >= stopAllele)
                {
                    offspring[idx] = swathDiff.First().Value;
                    swathDiff.Remove(swathDiff.First().Key);
                    if (swathDiff.Count > 0)
                    {
                        tryNum = swathDiff.First().Key;
                    }
                }
                else
                {
                    tryNum = idx;
                }
            }

            for (var i = 0; i < offspring.Count(); i++)
            {
                if (i == 0)
                {
                    offspring[i] = mother.ElementAt(i);
                }
            }

            return offspring;
        }
    }
}
