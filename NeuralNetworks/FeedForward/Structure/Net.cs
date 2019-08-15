using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworks.FeedForward.Structure
{
    public class Net : INet, ICloneable
    {
        public long Id { get; private set; }

        public ICollection<InputNeuron> InputNeurons { get; set; }
        public ICollection<INeuron> OutputNeurons { get; set; }

        public ICollection<INeuron> AllNeurons { get; set; }
        public ICollection<IConnection> AllConnections { get; set; }

        public Net(long id)
        {
            this.Id = id;
        }

        public IEnumerable<double> CalculateOutputs()
        {
            foreach(var cachedNeuron in AllNeurons.OfType<ACachedNeuron>())
            {
                cachedNeuron.ResetCache();
            }

            return OutputNeurons.Select(o => o.Value);
        }

        public void SetInputs(IEnumerable<double> values)
        {
            for(int i = 0; i < InputNeurons.Count; i++)
            {
                InputNeurons.ElementAt(i).Value = values.ElementAt(i);
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
