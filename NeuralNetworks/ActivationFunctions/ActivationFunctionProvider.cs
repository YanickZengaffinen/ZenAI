using System;
using System.Collections.Generic;

namespace NeuralNetworks.ActivationFunctions
{
    public class ActivationFunctionProvider
    {
        private readonly IDictionary<string, IActivationFunction> activationFunctions = new Dictionary<string, IActivationFunction>();

        public void Register<T>(T function)
            where T : IActivationFunction
        {
            lock(activationFunctions)
            {
                activationFunctions.Add(GetIdentifier(typeof(T)), function);
            }
        }

        public T Get<T>()
            where T : IActivationFunction
        {
            string id = GetIdentifier(typeof(T));
            lock(activationFunctions)
            {
                if(activationFunctions.ContainsKey(id))
                {
                    return (T)activationFunctions[id];
                }
            }

            return default;
        }

        private string GetIdentifier(Type t)
        {
            return t.FullName;
        }
    }
}
