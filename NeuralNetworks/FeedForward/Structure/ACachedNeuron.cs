using System.Collections.Generic;
using NeuralNetworks.ActivationFunctions;

namespace NeuralNetworks.FeedForward.Structure
{
    /// <summary>
    /// Neuron whos value is calculated once and then returned from cache until the cache is reset
    /// </summary>
    public abstract class ACachedNeuron : INeuron
    {
        public abstract double Bias { get; set; }
        public abstract ICollection<IConnection> InConnections { get; set; }
        public abstract ICollection<IConnection> OutConnections { get; set; }
        public abstract IActivationFunction ActivationFunction { get; set; }

        public bool CacheInitialized { get; private set; }

        private double cachedValue;

        public double Value
        {
            get
            {
                if (!CacheInitialized)
                {
                    cachedValue = CalculateCacheValue();
                    CacheInitialized = true;
                }

                return cachedValue;
            }

            set
            {
                cachedValue = value;
                CacheInitialized = true;
            }
        }

        public void ResetCache()
        {
            CacheInitialized = false;
        }

        public abstract double CalculateCacheValue();
    }
}
