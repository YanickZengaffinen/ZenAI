using NeuralNetworks.ActivationFunctions;
using System.Collections.Generic;

namespace NeuralNetworks.FeedForward.Structure.Data
{
    public interface INetData
    {
        long Id { get; }

        ICollection<INeuronData> AllNeurons { get; set; }

        ICollection<IConnectionData> AllConnections { get; set; }

        ICollection<long> InputNeuronIds { get; set; }

        ICollection<long> OutputNeuronIds { get; set; }
    }
}
