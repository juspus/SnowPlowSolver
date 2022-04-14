using SnowPlowSolver.Interfaces;
using SnowPlowSolver.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SnowPlowSolver
{
    public class GA : IGeneticAlgorithm
    {
        private int _Epochs;
        private int _PopulationSize;
        private double _MutationPercent;
        private List<ILine>? _Lines;
        private List<IIndividual> _Population;
        public IFitnessFunction FitnessFunction { get; }
        public IMutation Mutation { get; }
        public ICrossover Crossover { get; }
        private ISelection Selection;
        private IRandomizer Randomizer;
        private ISurvivorSelection SurvivorSelection;

        /// <summary>
        /// Setup of Genetic Algorithm.
        /// </summary>
        /// <param name="epochs">Number of iterations for Genetics Algorithm.</param>
        /// <param name="populationSize">Quantity of individuals in a genetic algorithm population.</param>
        /// <param name="mutationPercent">Percent of mutation probability at each crossover.</param>
        /// <param name="fitnessFunction">Function that evaluates the quality of single individual. If none provided, default is selected.</param>
        /// <param name="mutation">Type of individual mutation. Default is Swap Mutation.</param>
        /// <param name="crossover">Type of crossover between parents. Default is PMX.</param>
        /// <param name="selection">Type of parent selection. Default is Wheel selection.</param>
        /// <param name="survivorSelection">Type of survivor selection. Default is Fitness based Survivor Selection.</param>
        public GA(int epochs, int populationSize, double mutationPercent,
            IFitnessFunction fitnessFunction = null,
            IMutation mutation = null,
            ICrossover crossover = null,
            ISelection selection = null,
            ISurvivorSelection survivorSelection = null)
        {
            _Epochs = epochs;
            _PopulationSize = populationSize;
            _MutationPercent = mutationPercent;
            Randomizer = new Randomizer();
            if (fitnessFunction == null)
                fitnessFunction = new FitnessFunction();
            if (mutation == null)
                mutation = new SwapMutation(Randomizer);
            if (crossover == null)
                crossover = new PMX(Randomizer);
            if (selection == null)
                selection = new WheelSelection(Randomizer);
            if (survivorSelection == null)
                survivorSelection = new FitnessBasedSurvivorSelection();

            this.FitnessFunction = fitnessFunction;
            this.Mutation = mutation;
            this.Crossover = crossover;
            this.Selection = selection;
            this.SurvivorSelection = survivorSelection;
        }

        private void Evolution()
        {
            var offsprings = new ConcurrentBag<IIndividual>();
            _Population = _Population.OrderByDescending(x => x.Score).ToList();
            for (var j = 0; j < _Population.Count; j++)
            {
                var papa = Selection.SelectParent(_Population);
                var mama = Selection.SelectParent(_Population);
                var offspring = mama.Cross(papa);
                if (Randomizer.GeneratePercent() < _MutationPercent)
                {
                    offspring.Mutate();
                }
                offsprings.Add(offspring);
            }
            //Parallel.For(0, _PopulationSize, (j) =>
            //{
            //    var papa = Selection.SelectParent(_Population);
            //    var mama = Selection.SelectParent(_Population);
            //    var offspring = mama.Cross(papa);
            //    if (Randomizer.GeneratePercent() < _MutationPercent)
            //    {
            //        offspring.Mutate();
            //    }
            //    offsprings.Add(offspring);
            //});
            _Population = SurvivorSelection.GetSurvivors(_Population, offsprings).ToList();
            
        }

        /// <summary>
        /// Optimizes the path with a setup genetic algorithm.
        /// </summary>
        /// <param name="lines">Collection of lines for which to optimize path.</param>
        /// <returns>Optimized path.</returns>
        public IEnumerable<ILine> OptimizePath(IEnumerable<ILine> lines)
        {
            _Lines = lines.ToList();
            Populate();
            for (var i = 0; i< _Epochs; i++)
            {
                Evolution();
                Console.WriteLine(_Population.First().Score);
            }
            return _Population.OrderBy(x => x.Score).First().Path;
        }
        private void Populate()
        {
            _Population = new List<IIndividual>();
            for(var i = 0; i< _PopulationSize; i++)
            {
                Shuffle(_Lines);
                _Population.Add(new Individual(this, _Lines.ToList()));
            }
        }
        private void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Randomizer.GenerateBetween(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
