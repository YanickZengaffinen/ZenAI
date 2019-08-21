using Common.Registries;
using System;

namespace Common.Services
{
    /// <summary>
    /// Allows for dependency injection and SPI logic
    /// </summary>
    public class ServiceRegistry : Registry<object>
    {
        private static readonly Lazy<ServiceRegistry> instance = new Lazy<ServiceRegistry>(() => new ServiceRegistry());
        public static ServiceRegistry Instance
            => instance.Value;
    }
}
