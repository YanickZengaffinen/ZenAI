using System;

namespace NeuralNetworks.ActivationFunctions
{
    public class SigmoidFunction : IActivationFunction
    {
        public double Apply(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }
    }
}
