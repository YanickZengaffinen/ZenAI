using NeuralNetworks.ActivationFunctions;
using NeuralNetworks.FeedForward.Structure;
using NeuralNetworks.FeedForward.Structure.Data;
using System.Collections.Generic;
using System.Linq;
using TrainerAPI.Services;

namespace NeuralNetworks.FeedForward
{
    public static class NetBuilderExtensions
    {
        /// <summary>
        /// Builds a net from a given structure
        /// </summary>
        /// <param name="data">The data defining the nets structure</param>
        public static INet Build(this INetData data)
        {
            var activationFunctionProvider = ServiceRegistry.Instance.Get<ActivationFunctionProvider>();
            var allConnections = new List<IConnection>(data.AllConnections.Count);
            var neuronsById = new Dictionary<long, INeuron>();

            // Initialize all connections and instantiate dummy neurons that will be fully initialized later
            foreach(var connectionData in data.AllConnections)
            {
                // Check if the origin neuron already exists, if not add a new one
                if (!neuronsById.TryGetValue(connectionData.OriginNeuronId, out INeuron origin))
                {
                    origin = new Neuron(connectionData.OriginNeuronId);
                    neuronsById.Add(connectionData.OriginNeuronId, origin);
                }

                // Check if the destination neuron already exists, if not add a new one
                if (!neuronsById.TryGetValue(connectionData.DestinationNeuronId, out INeuron destination))
                {
                    destination = new Neuron(connectionData.DestinationNeuronId);
                    neuronsById.Add(connectionData.DestinationNeuronId, destination);
                }

                // Initialize the connection and add it to the connected neurons
                var connection = new Connection(connectionData.Id, connectionData.Weight, origin, destination);
                allConnections.Add(connection);
                origin.OutConnections.Add(connection);
                destination.InConnections.Add(connection);
            }

            // Fully initialize the dummy neurons
            foreach(var neuronData in data.AllNeurons)
            {
                var neuron = neuronsById[neuronData.Id];
                neuron.Bias = neuronData.Bias;
                neuron.ActivationFunction = activationFunctionProvider.Get<IActivationFunction>(neuronData.ActivationFunction);
            }

            // Get the input & output neurons
            var inputNeurons = data.InputNeuronIds.Select(id => neuronsById[id]).ToList();
            var outputNeurons = data.OutputNeuronIds.Select(id => neuronsById[id]).ToList();

            return new Net(data.Id) {
                AllNeurons = neuronsById.Values,
                AllConnections = allConnections,
                InputNeurons = inputNeurons,
                OutputNeurons = outputNeurons
            };
        }

        public static INetData Data(this INet net)
        {
            return new NetData(
                net.Id, 
                net.AllNeurons.Select(n => n.Data()).ToList(), net.AllConnections.Select(c => c.Data()).ToList(), 
                net.InputNeurons.Select(n => n.Id).ToList(), net.OutputNeurons.Select(n => n.Id).ToList());
        }

        public static INeuronData Data(this INeuron neuron)
            => new NeuronData(neuron.Id, neuron.Bias, neuron.ActivationFunction.GetType().FullName, neuron.InConnections.Select(c => c.Id).ToList(), neuron.OutConnections.Select(c => c.Id).ToList());

        public static IConnectionData Data(this IConnection connection)
            => new ConnectionData(connection.Id, connection.Weight, connection.Origin.Id, connection.Destination.Id);
    }
}
