using System;
using System.Collections.Generic;

namespace RandomExtension
{
    public static class RandomContainer
    {
        private static readonly Dictionary<int, Random> Randoms = new Dictionary<int, Random>();

        private static Random GetRandomInstance(int seed)
        {
            Random instance;
            if (Randoms.TryGetValue(seed, out instance))
                return instance;
            instance = new Random(seed);
            Randoms.Add(seed, instance);
            return instance;
        }

        public static int GetInteger(int bottom, int top, int seed = 0)
        {
            Random randomInstance = GetRandomInstance(seed);
            return randomInstance.Next(bottom, top + 1);
        }

        public static double GetDouble(double bottom, double top, int seed = 0)
        {
            Random randomInstance = GetRandomInstance(seed);
            return (top - bottom) * randomInstance.NextDouble() + bottom;
        }

        public static int[] GetIntegerArray(int bottom, int top, int length, int seed = 0)
        {
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
                result[i] = GetInteger(bottom, top, seed);
            return result;
        }

        public static double[] GetDoubleArray(double bottom, double top, int length, int seed = 0)
        {
            double[] result = new double[length];
            for (int i = 0; i < length; i++)
                result[i] = GetDouble(bottom, top, seed);
            return result;
        }
    }
}
