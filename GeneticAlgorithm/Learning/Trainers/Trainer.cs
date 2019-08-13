using GeneticAlgorithm.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm.Learning.Trainers
{
    public class Trainer<T>
        where T : IMutant
    {
        public double Epsilon { get; private set; } = 0.01;

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

        public void Train(int epochs, Action<EpochInfo<T>> epochTrainedCallback = null, Action<T> successCallback = null)
        {
            for(int i = 0; i < epochs; i++)
            {
                var newPopulation = Optimizer.Optimize(CurrentPopulation, out IEnumerable<PerformanceResult<T>> ranking);

                var epochInfo = new EpochInfo<T>(i, CurrentPopulation, newPopulation, ranking);
                epochTrainedCallback?.Invoke(epochInfo);

                if(Math.Abs(epochInfo.MinError) <= Epsilon)
                {
                    successCallback?.Invoke(epochInfo.Best);
                }

                CurrentPopulation = newPopulation;
            }
        }
    }
}
