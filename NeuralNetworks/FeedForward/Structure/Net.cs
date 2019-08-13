using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworks.FeedForward.Structure
{
    public class Net : INet
    {
        public ICollection<InputNeuron> InputNeurons { get; set; }
        public ICollection<INeuron> OutputNeurons { get; set; }

        public ICollection<INeuron> AllNeurons { get; set; }
        public ICollection<IConnection> AllConnections { get; set; }

        public IEnumerable<double> CalculateOutputs()
        {
            return OutputNeurons.Select(o => o.Value);
        }

        public void SetInputs(IEnumerable<double> values)
        {
            for(int i = 0; i < InputNeurons.Count; i++)
            {
                InputNeurons.ElementAt(i).Value = values.ElementAt(i);
            }
        }
    }
}
