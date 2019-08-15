using NeuralNetworks.ActivationFunctions;
using System.Collections.Generic;

namespace NeuralNetworks.FeedForward.Structure
{
    public interface INeuron
    {
        long Id { get; }

        ICollection<IConnection> InConnections { get; set; }

        ICollection<IConnection> OutConnections { get; set; }

        IActivationFunction ActivationFunction { get; set; }

        /// <summary>
        /// The last calculated value
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// The bias of this neuron
        /// </summary>
        double Bias { get; set; }
    }
}
