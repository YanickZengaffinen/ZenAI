using GeneticAlgorithm.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm.Learning.Trainers
{
    public class EpochInfo<T>
        where T : IMutant
    {
        public int Epoch { get; private set; }

        public Population<T> StartPopulation { get; private set; }

        public Population<T> EndPopulation { get; private set; }

        public IEnumerable<PerformanceResult<T>> Ranking { get; private set; }

        public double AverageError { get; private set; }

        public double MinError { get; private set; }

        public double MaxError { get; private set; }

        public T Best => Ranking.First().Entity;

        public T Worst => Ranking.Last().Entity;

        public EpochInfo(int epoch, Population<T> start, Population<T> end, IEnumerable<PerformanceResult<T>> ranking)
        {
            this.Epoch = epoch;
            this.StartPopulation = start;
            this.EndPopulation = end;
            this.Ranking = ranking;

            double min = double.MaxValue;
            double total = 0;
            int cnt = 0;
            double max = double.MinValue;
            foreach(var r in ranking)
            {
                if (r.Error < min)
                    min = r.Error;

                if (r.Error > max)
                    max = r.Error;

                total += r.Error;
                cnt++;
            }

            AverageError = total / cnt;
            MinError = min;
            MaxError = max;
        }
    }
}
