using System;
using System.Collections.Generic;

namespace NeuralNetworks.FeedForward.Structure
{
    public interface INet
    {
        long Id { get; }

        ICollection<INeuron> AllNeurons { get; set; }

        ICollection<INeuron> InputNeurons { get; set; }

        ICollection<INeuron> OutputNeurons { get; set; }

        ICollection<IConnection> AllConnections { get; set; }

        void SetInputs(IEnumerable<double> values);

        IEnumerable<double> CalculateOutputs();

        INet Clone();
    }
}
