using System.Collections.Generic;

namespace Helab.Helper
{
    public static class Displace
    {
        public static void Do<TKey, TValue>(TKey key, Dictionary<TKey, TValue> from, Dictionary<TKey, TValue> to)
        {
            var value = from[key];
            to.Add(key, value);
            from.Remove(key);
        }
    }
}
