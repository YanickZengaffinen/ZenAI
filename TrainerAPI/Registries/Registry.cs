using System;
using System.Collections.Generic;

namespace TrainerAPI.Registries
{
    public class Registry<B> : IRegistry<B>
    {
        protected IDictionary<string, B> registry = new Dictionary<string, B>();
        public void Register<T>(T entity, Type alias = null) where T : B
        {
            registry.Add(GetIdentifier(alias ?? typeof(T)), entity);
        }

        public T Get<T>()
            where T : B
        {
            string alias = GetIdentifier(typeof(T));
            if (registry.ContainsKey(alias))
            {
                return (T)registry[alias];
            }
            else
            {
                throw new Exception($"Entity with name {alias} not found!");
            }
        }


        public bool Unregister(Type alias)
        {
            return registry.Remove(GetIdentifier(alias));
        }


        private string GetIdentifier(Type t)
            => t.FullName;
    }
}
