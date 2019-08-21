using System;
using System.Collections.Generic;

namespace NeuralNetworks.ActivationFunctions
{
    public class ActivationFunctionProvider
    {
        private readonly IDictionary<string, IActivationFunction> activationFunctions = new Dictionary<string, IActivationFunction>();

        public ActivationFunctionProvider()
        {
            //register built in activation functions
            Register(new SigmoidFunction());
        }

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
                => Get<T>(GetIdentifier(typeof(T)));

        public T Get<T>(string id)
            where T : IActivationFunction
        {
            lock (activationFunctions)
            {
                if (activationFunctions.ContainsKey(id))
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
