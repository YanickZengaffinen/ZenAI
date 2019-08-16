namespace NeuralNetworks.FeedForward.Structure.Data
{
    public interface IConnectionData
    {
        long Id { get; }

        double Weight { get; set; }

        long OriginNeuronId { get; set; }

        long DestinationNeuronId { get; set; }
    }
}
