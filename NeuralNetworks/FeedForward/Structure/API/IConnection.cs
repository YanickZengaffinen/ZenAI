namespace NeuralNetworks.FeedForward.Structure
{
    public interface IConnection
    {
        double Weight { get; set; }

        INeuron Origin { get; set; }

        INeuron Destination { get; set; }
    }
}
