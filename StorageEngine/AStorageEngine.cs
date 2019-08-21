using System;

namespace StorageEngine
{
    public abstract class AStorageEngine<T> : IStorageEngine<T>
    {
        public abstract void Save(T entity);

        public void Save(object entity)
            => Save((T)entity);

        public Type TargetType
            => typeof(T);
    }
}
