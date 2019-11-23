using System;

namespace AdapterPattern.Util
{
    public static class RandomString
    {
        // Random seed
        private static readonly Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public static string Create(int count)
        {
            string output = "";

            for (var i = 0; i <= count; i++)
            {
                output += (char)_rng.Next('a', 'z');
            }

            return output;
        }
    }
}
