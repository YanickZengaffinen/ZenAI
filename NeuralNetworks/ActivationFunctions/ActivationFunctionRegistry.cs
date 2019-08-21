using Common.Registries;

namespace NeuralNetworks.ActivationFunctions
{
    public class ActivationFunctionRegistry : Registry<IActivationFunction>
    {
        public ActivationFunctionRegistry()
        {
            //register built in activation functions
            Register(new SigmoidFunction());
        }

        public T Get<T>(string id)
            where T : IActivationFunction
        {
            lock (registry)
            {
                if (registry.ContainsKey(id))
                {
                    return (T)registry[id];
                }
            }

            return default;
        }
    }
}
