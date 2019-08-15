using System.Collections.Generic;
using NeuralNetworks.ActivationFunctions;

namespace NeuralNetworks.FeedForward.Structure
{
    public class InputNeuron : INeuron
    {
        public long Id { get; private set; }

        /// <summary>
        /// Hint: InConnections are not used by input neurons
        /// </summary>
        public ICollection<IConnection> InConnections { get; set; }

        public ICollection<IConnection> OutConnections { get; set; }

        /// <summary>
        /// Hint: ActivationFunction is not used by input neurons
        /// </summary>
        public IActivationFunction ActivationFunction { get; set; }
        public double Value { get; set; }

        public InputNeuron(long id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Hint: Will always be 0 for input neurons
        /// </summary>
        public double Bias
        {
            get { return 0; }
            set { }
        }

        public InputNeuron()
        {

        }
    }
}
