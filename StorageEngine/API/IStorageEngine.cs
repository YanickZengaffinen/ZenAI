using System;

namespace StorageEngine
{
    /// <summary>
    /// Required to build a registry of different storage engines
    /// </summary>
    public interface IStorageEngine
    {
        void Save(object entity);

        Type TargetType { get; }
    }

    public interface IStorageEngine<in T> : IStorageEngine
    {
        void Save(T entity);
    }
}
