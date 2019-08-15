namespace NeuralNetworks.FeedForward.Structure
{
    public interface IConnection
    {
        long Id { get; }

        double Weight { get; set; }

        INeuron Origin { get; set; }

        INeuron Destination { get; set; }
    }
}
