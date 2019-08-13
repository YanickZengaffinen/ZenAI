using System;
using System.Collections.Generic;
using System.Text;

namespace Random
{
    public class DefaultRangeRandomGenerator : IRandomGenerator
    {
        public double Min { get; private set; }

        public double Max { get; private set; }

        private double range;

        private readonly System.Random random;

        public DefaultRangeRandomGenerator(double min, double max)
        {
            this.Min = min;
            this.Max = max;

            range = Max - Min;

            random = new System.Random();
        }

        public double Generate()
        {
            return random.NextDouble() * range + Min;
        }
    }
}
