using System.Collections.Generic;

namespace NeuralNetworks.FeedForward.Structure.Data
{
    public class NetData : INetData
    {
        public long Id { get; }
        public ICollection<INeuronData> AllNeurons { get; set; }
        public ICollection<IConnectionData> AllConnections { get; set; }
        public ICollection<long> InputNeuronIds { get; set; }
        public ICollection<long> OutputNeuronIds { get; set; }

        public NetData(
            in long id, 
            ICollection<INeuronData> allNeurons, ICollection<IConnectionData> allConnections, 
            ICollection<long> inputNeuronIds, ICollection<long> outputNeuronIds)
        {
            Id = id;
            AllNeurons = allNeurons;
            AllConnections = allConnections;
            InputNeuronIds = inputNeuronIds;
            OutputNeuronIds = outputNeuronIds;
        }
    }
}
