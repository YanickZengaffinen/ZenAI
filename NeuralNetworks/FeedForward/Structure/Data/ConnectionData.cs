namespace NeuralNetworks.FeedForward.Structure.Data
{
    public class ConnectionData : IConnectionData
    {
        public long Id { get; }

        public double Weight { get; set; }
        public long OriginNeuronId { get; set; }
        public long DestinationNeuronId { get; set; }

        public ConnectionData(in long id, in double weight, in long origin, in long destination)
        {
            this.Id = id;
            this.Weight = weight;
            this.OriginNeuronId = origin;
            this.DestinationNeuronId = destination;
        }
    }
}
