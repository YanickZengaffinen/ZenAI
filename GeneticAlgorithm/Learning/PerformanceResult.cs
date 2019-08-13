using GeneticAlgorithm.Mutation;
using System;

namespace GeneticAlgorithm.Learning
{
    public struct PerformanceResult<T>
        where T : IMutant
    {
        public T Entity { get; private set; }

        /// <summary>
        /// How badly the entity has performed
        /// Always positive
        /// </summary>
        public double Error { get; private set; }

        public PerformanceResult(T entity, double error)
        {
            this.Entity = entity;
            this.Error = Math.Abs(error);
        }
    }
}
