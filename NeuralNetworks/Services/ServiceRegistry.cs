using System;
using System.Collections.Generic;

namespace NeuralNetworks.Services
{
    /// <summary>
    /// Allows for dependency injection and SPI logic
    /// </summary>
    public class ServiceRegistry
    {
        private static readonly Lazy<ServiceRegistry> instance = new Lazy<ServiceRegistry>(() => new ServiceRegistry());
        public static ServiceRegistry Instance
            => instance.Value;

        private readonly IDictionary<string, object> services = new Dictionary<string, object>();

        /// <summary>
        /// Register a service
        /// </summary>
        /// <param name="type">Under which type do you want to register the service. E.g. Car could be registered as ICar</param>
        public void Register<T>(T service, Type type = null)
        {
            services.Add(GetIdentifier(type ?? typeof(T)), service);
        }

        /// <summary>
        /// Get the service that is registered for a given type
        /// </summary>
        public T GetService<T>()
        {
            string serviceName = GetIdentifier(typeof(T));
            if(services.ContainsKey(serviceName))
            {
                return (T)services[serviceName];
            }
            else
            {
                throw new Exception($"Service with na^me {serviceName} not found");
            }
        }

        private string GetIdentifier(Type t)
            => t.FullName;
    }
}
