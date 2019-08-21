using GeneticAlgorithm.Learning.ErrorFunctions;
using GeneticAlgorithm.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm.Learning
{
    /// <summary>
    /// Simulates an environment for a certain population and records which entities survive
    /// </summary>
    public class Optimizer<T>
        where T : IMutant
    {
        public IErrorFunction<T> ErrorFunction { get; private set; }

        /// <summary>
        /// The percentage of entities that will survive each epoch
        /// </summary>
        public double SurvivalPercentage { get; private set; }

        public Optimizer(IErrorFunction<T> errorFunction, double survivalPercentage = 0.1d)
        {
            this.ErrorFunction = errorFunction;
            this.SurvivalPercentage = survivalPercentage;
        }

        public Population<T> Optimize(Population<T> population, out IEnumerable<PerformanceResult<T>> ranking)
        {
            int decimatedPopulationSize = (int)(population.Size * SurvivalPercentage);
            int emptyPopulationSpace = population.Size - decimatedPopulationSize;

            ranking = population.Entities
                .Select(x => new PerformanceResult<T>(x, ErrorFunction.CalculateError(x)))
                .OrderBy(x => x.Loss);

            var performances = ranking
                .Take(decimatedPopulationSize)
                .ToList();

            var totalErrorOfSurvived = performances.Select(x => Math.Abs(x.Loss)).Sum();

            var newPopulationEntities = new List<T>(population.Size);

            //generate the new population, prioritise according to ~ 1 / error
            foreach (var performance in performances)
            {
                newPopulationEntities.Add(performance.Entity);

                double offsetPercentage = (1 - Math.Abs(performance.Loss) / totalErrorOfSurvived) / (decimatedPopulationSize - 1);
                int offsetAmount = (int)(offsetPercentage * emptyPopulationSpace);

                for(int i = 0; i < offsetAmount; i++)
                {
                    newPopulationEntities.Add((T)performance.Entity.Mutate());
                }
            }

            //fill the rest of the population beginning from the baddest survivor
            var restPopulationSpace = population.Size - newPopulationEntities.Count;
            for(int i = 0; i < restPopulationSpace; i++)
            {
                newPopulationEntities.Add((T)performances[i % performances.Count()].Entity.Mutate());
            }

            return new Population<T>(newPopulationEntities, population.Size);
        }
    }
}
