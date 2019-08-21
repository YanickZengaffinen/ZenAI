using GeneticAlgorithm.Mutation;

namespace GeneticAlgorithm.Learning
{
    public struct PerformanceResult<T>
        where T : IMutant
    {
        public T Entity { get; }

        /// <summary>
        /// How badly the entity has performed
        /// 
        /// Expected to be positive
        /// </summary>
        public double Loss { get; }

        public PerformanceResult(T entity, double loss)
        {
            this.Entity = entity;
            this.Loss = loss;
        }
    }
}
