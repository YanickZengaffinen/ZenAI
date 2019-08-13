namespace Random
{
    /// <summary>
    /// Random number generator using the <see cref="System.Random"/> generator
    /// </summary>
    public class DefaultRandomGenerator : IRandomGenerator
    {
        private readonly System.Random random;

        public DefaultRandomGenerator()
        {
            this.random = new System.Random();
        }

        public double Generate()
        {
            return random.NextDouble();
        }
    }
}
