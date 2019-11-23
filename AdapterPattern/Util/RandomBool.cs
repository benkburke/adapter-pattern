using System;

namespace AdapterPattern.Util
{
    public static class RandomBool
    {
        // Random seed
        private static readonly Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public static bool Create()
        {
            return _rng.NextDouble() >= 0.5;
        }
    }
}
