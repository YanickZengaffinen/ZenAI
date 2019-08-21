using GeneticAlgorithm.Mutation;
using System.Collections.Generic;
using TrainerAPI;

namespace GeneticAlgorithm.Learning.Trainers
{
    public class Trainer<T> : ITrainer<EpochInfo<T>>
        where T : IMutant
    {
        public Optimizer<T> Optimizer { get; private set; }

        public Population<T> CurrentPopulation { get; private set; }

        public Trainer(T entity, int populationSize, Optimizer<T> optimizer)
        {
            this.Optimizer = optimizer;

            var entities = new List<T>(populationSize);
            for(int i = 0; i < populationSize; i++)
            {
                entities.Add((T)entity.Mutate());
            }

            CurrentPopulation = new Population<T>(entities, populationSize);
        }

        public IEnumerable<EpochInfo<T>> Train(int epochs, IDictionary<string, object> parameters)
        {
            for(int i = 0; i < epochs; i++)
            {
                var newPopulation = Optimizer.Optimize(CurrentPopulation, out IEnumerable<PerformanceResult<T>> ranking);

                yield return new EpochInfo<T>(i, CurrentPopulation, newPopulation, ranking);

                CurrentPopulation = newPopulation;
            }
        }
    }
}
