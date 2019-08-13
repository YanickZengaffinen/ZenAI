using NeuralNetworks.ActivationFunctions;
using NeuralNetworks.FeedForward.Structure;
using Random;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworks.FeedForward
{
    public class NetBuilder
    {
        private readonly IRandomGenerator weightRandom;
        private readonly IRandomGenerator biasRandom;

        public NetBuilder(IRandomGenerator weightRandom, IRandomGenerator biasRandom)
        {
            this.weightRandom = weightRandom;
            this.biasRandom = biasRandom;
        }

        #region Single
        public IConnection Connect(INeuron origin, INeuron destination)
        {
            var connection = new Connection(weightRandom.Generate(), origin, destination);
            origin.OutConnections.Add(connection);
            destination.InConnections.Add(connection);

            return connection;
        }

        public INeuron Create(IActivationFunction activationFunction)
        {
            return new Neuron()
            {
                ActivationFunction = activationFunction,
                Bias = biasRandom.Generate()
            };
        }

        public InputNeuron CreateInput()
        {
            return new InputNeuron();
        }
        #endregion

        #region Layer
        /// <summary>
        /// Fully connects two layers of neurons
        /// </summary>
        public IEnumerable<IConnection> ConnectLayer(IEnumerable<INeuron> origins, IEnumerable<INeuron> destinations)
        {
            return origins.SelectMany(o => destinations.Select(d => Connect(o, d)));
        }

        public IEnumerable<INeuron> CreateLayer(IActivationFunction activationFunction, int size)
        {
            return Enumerable.Range(0, size)
                .Select(i => Create(activationFunction));
        }

        public IEnumerable<InputNeuron> CreateInputLayer(int size)
        {
            return Enumerable.Range(0, size)
                .Select(i => CreateInput());
        }

        #endregion

        #region Net
        /// <summary>
        /// Creates a fully connected feed forward neural network
        /// </summary>
        public void CreateNet(IActivationFunction activationFunction, int inputSize, IEnumerable<int> hiddenLayerSizes, int outputLayerSize)
        {
            var net = new Net();

            net.InputNeurons = CreateInputLayer(inputSize).ToList();
            var lastLayer = net.InputNeurons.Cast<INeuron>();
            foreach(var layerSize in hiddenLayerSizes)
            {
                var layer = CreateLayer(activationFunction, layerSize);
                net.AllConnections = net.AllConnections.Concat(ConnectLayer(lastLayer, layer)).ToList();
                lastLayer = layer;
            }

            net.OutputNeurons = CreateLayer(activationFunction, outputLayerSize).ToList();
            ConnectLayer(lastLayer, net.OutputNeurons);
        }
        #endregion
    }
}