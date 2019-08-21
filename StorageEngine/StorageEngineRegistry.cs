using Common.Registries;
using System.Linq;

namespace StorageEngine
{
    public class StorageEngineRegistry : Registry<IStorageEngine>
    {
        /// <summary>
        /// Get the storage engine for a certain type
        /// </summary>
        public IStorageEngine<T> For<T>()
            => (IStorageEngine<T>)registry.Values.FirstOrDefault(x => x.TargetType == typeof(T));
    }
}
