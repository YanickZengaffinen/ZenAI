using System.Collections.Generic;

namespace NeuralNetworks.FeedForward.Structure.Data
{
    public interface INeuronData
    {
        long Id { get; }

        double Bias { get; set; }

        string ActivationFunction { get; set; }

        ICollection<long> InConnectionIds { get; set; }

        ICollection<long> OutConnectionIds { get; set; }
    }
}
