namespace NeuralNetworks.FeedForward.Structure
{
    public class Connection : IConnection
    {
        public long Id { get; set; }
        public double Weight { get; set; }
        public INeuron Origin { get; set; }
        public INeuron Destination { get; set; }

        public Connection(in long id, in double weight, INeuron origin, INeuron destination)
        {
            this.Id = id;
            this.Weight = weight;
            this.Origin = origin;
            this.Destination = destination;
        }
    }
}
