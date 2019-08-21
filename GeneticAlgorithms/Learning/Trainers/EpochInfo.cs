using GeneticAlgorithm.Mutation;
using System.Collections.Generic;
using System.Linq;
using TrainerAPI;

namespace GeneticAlgorithm.Learning.Trainers
{
    public class EpochInfo<T> : IEpochInfo
        where T : IMutant
    {
        public int Id { get; private set; }

        /// <summary>
        /// The average loss of the resulting population
        /// </summary>
        public double Loss { get; private set; }

        public Population<T> StartPopulation { get; private set; }

        public Population<T> EndPopulation { get; private set; }

        public IEnumerable<PerformanceResult<T>> Ranking { get; private set; }

        public double MinLoss { get; private set; }

        public double MaxLoss { get; private set; }

        public T Best => Ranking.First().Entity;

        public T Worst => Ranking.Last().Entity;

        public EpochInfo(int id, Population<T> start, Population<T> end, IEnumerable<PerformanceResult<T>> ranking)
        {
            this.Id = id;
            this.StartPopulation = start;
            this.EndPopulation = end;
            this.Ranking = ranking;

            double min = double.MaxValue;
            double total = 0;
            int cnt = 0;
            double max = double.MinValue;
            foreach(var r in ranking)
            {
                if (r.Loss < min)
                    min = r.Loss;

                if (r.Loss > max)
                    max = r.Loss;

                total += r.Loss;
                cnt++;
            }

            Loss = total / cnt;
            MinLoss = min;
            MaxLoss = max;
        }
    }
}
