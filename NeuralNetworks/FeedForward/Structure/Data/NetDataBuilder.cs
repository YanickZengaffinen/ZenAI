using Random;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworks.FeedForward.Structure.Data
{
    public class NetDataBuilder
    {
        private readonly IRandomGenerator weightRandom;
        private readonly IRandomGenerator biasRandom;

        public long CurrentId = long.MinValue;

        public NetDataBuilder(IRandomGenerator weightRandom, IRandomGenerator biasRandom)
        {
            this.weightRandom = weightRandom;
            this.biasRandom = biasRandom;
        }

        #region Single
        public IConnectionData Connect(INeuronData origin, INeuronData destination)
        {
            var connection = new ConnectionData(ReserveId(), weightRandom.Generate(), origin.Id, destination.Id);
            origin.OutConnectionIds.Add(connection.Id);
            destination.OutConnectionIds.Add(connection.Id);

            return connection;
        }

        public INeuronData Create(string activationFunction)
        {
            return new NeuronData(ReserveId(), biasRandom.Generate(), activationFunction, new List<long>(), new List<long>());
        }

        public INeuronData CreateInput()
        {
            return new NeuronData(ReserveId(), 0, null, new List<long>(), new List<long>());
        }
        #endregion

        #region Layer
        /// <summary>
        /// Fully connects two layers of neurons
        /// </summary>
        public IEnumerable<IConnectionData> ConnectLayer(IEnumerable<INeuronData> origins, IEnumerable<INeuronData> destinations)
        {
            return origins.SelectMany(o => destinations.Select(d => Connect(o, d)));
        }

        public IEnumerable<INeuronData> CreateLayer(string activationFunction, int size)
        {
            return Enumerable.Range(0, size)
                .Select(i => Create(activationFunction));
        }

        public IEnumerable<INeuronData> CreateInputLayer(int size)
        {
            return Enumerable.Range(0, size)
                .Select(i => CreateInput());
        }
        #endregion

        #region Net
        /// <summary>
        /// Creates a fully connected feed forward neural network
        /// </summary>
        public INetData CreateNet(string activationFunction, int inputSize, IEnumerable<int> hiddenLayerSizes, int outputLayerSize)
        {
            var allNeurons = new List<INeuronData>();
            var allConnections = new List<IConnectionData>();

            var inputNeurons = CreateInputLayer(inputSize);
            var inputNeuronIds = inputNeurons.Select(x => x.Id);
            allNeurons.AddRange(inputNeurons);

            var lastLayer = inputNeurons;
            foreach(var layerSize in hiddenLayerSizes)
            {
                var layerNeurons = CreateLayer(activationFunction, layerSize);
                allNeurons.AddRange(layerNeurons);
                allConnections.AddRange(ConnectLayer(lastLayer, layerNeurons));
                lastLayer = layerNeurons;
            }

            var outputNeurons = CreateLayer(activationFunction, outputLayerSize);
            var outputNeuronIds = outputNeurons.Select(x => x.Id);
            allConnections.AddRange(ConnectLayer(lastLayer, outputNeurons));

            return new NetData(ReserveId(), allNeurons, allConnections, inputNeuronIds.ToList(), outputNeuronIds.ToList());
        }
        #endregion

        public long ReserveId()
        {
            return CurrentId++;
        }
    }
}