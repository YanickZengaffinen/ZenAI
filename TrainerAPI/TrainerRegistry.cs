using System.Collections.Generic;
using TrainerAPI.Registries;

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
