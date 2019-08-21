using Common.Registries;
using System.Collections.Generic;

namespace TrainerAPI
{
    public class TrainerRegistry : Registry<ITrainer<IEpochInfo>>
    {
        public IEnumerable<ITrainer<IEpochInfo>> GetAll()
        {
            return registry.Values;
        }
    }
}
