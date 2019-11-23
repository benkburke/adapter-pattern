using System;

namespace AdapterPattern.Util
{
    public static class RandomNumber
    {
        // Random seed
        private static readonly Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public static int Create(int min, int max)
        {
            return _rng.Next(min, max);
        }
    }
}
