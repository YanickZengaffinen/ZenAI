using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks.FeedForward.Structure
{
    public class Connection : IConnection
    {
        public double Weight { get; set; }
        public INeuron Origin { get; set; }
        public INeuron Destination { get; set; }

        public Connection(in double weight, INeuron origin, INeuron destination)
        {
            this.Weight = weight;
            this.Origin = origin;
            this.Destination = destination;
        }
    }
}
