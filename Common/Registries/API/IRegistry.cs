using System;

namespace Common.Registries
{
    /// <summary>
    /// A registry of objects that derive from B
    /// </summary>
    public interface IRegistry<B>
    {
        /// <param name="alias">Optional alias instead of the default name</param>
        void Register<T>(T entity, Type alias = null) where T : B;

        T Get<T>() where T : B;

        bool Unregister(Type alias);
    }
}
