using System.Collections.Generic;

namespace NeuralNetworks.FeedForward.Structure.Data
{
    public class NeuronData : INeuronData
    {
        public long Id { get; }

        public double Bias { get; set; }
        public string ActivationFunction { get; set; }
        public ICollection<long> InConnectionIds { get; set; }
        public ICollection<long> OutConnectionIds { get; set; }

        public NeuronData(in long id, in double bias, string activationFunction, ICollection<long> inConnectionIds, ICollection<long> outConnectionIds)
        {
            this.Id = id;
            this.Bias = bias;
            this.ActivationFunction = activationFunction;
            this.InConnectionIds = inConnectionIds;
            this.OutConnectionIds = outConnectionIds;
        }
    }
}
