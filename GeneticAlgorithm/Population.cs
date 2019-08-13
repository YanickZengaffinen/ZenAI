using GeneticAlgorithm.Mutation;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Population<T>
        where T : IMutant
    {
        public int Size { get; private set; }

        public IEnumerable<T> Entities { get; private set; }
        public object Select { get; internal set; }

        public Population(IEnumerable<T> entities, int maxSize = -1)
        {
            this.Entities = new List<T>(entities);
            Size = maxSize > 0 ? maxSize : entities.Count();
        }
    }
}
