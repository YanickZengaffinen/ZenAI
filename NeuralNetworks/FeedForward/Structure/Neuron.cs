using System.Collections.Generic;
using System.Linq;
using NeuralNetworks.ActivationFunctions;

namespace NeuralNetworks.FeedForward.Structure
{
    public class Neuron : ACachedNeuron
    {
        public override double Bias { get; set; }
        public override ICollection<IConnection> InConnections { get; set; } = new List<IConnection>();
        public override ICollection<IConnection> OutConnections { get; set; } = new List<IConnection>();
        public override IActivationFunction ActivationFunction { get; set; }

        public override double CalculateCacheValue()
        {
            return ActivationFunction.Apply(InConnections.Sum(x => x.Origin.Value * x.Weight) + Bias);
        }
    }
}
