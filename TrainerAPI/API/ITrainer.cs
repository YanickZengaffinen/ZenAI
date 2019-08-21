using System.Collections.Generic;

namespace TrainerAPI
{
    public interface ITrainer<out T>
        where T : IEpochInfo
    {
        // TODO: Use async streams once .net std 2.1 is released
        IEnumerable<T> Train(int epochs);
    }
}
