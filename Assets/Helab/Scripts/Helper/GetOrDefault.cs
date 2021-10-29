using System.Collections.Generic;

namespace Helab.Helper
{
    public static class GetOrDefault
    {
        public static T Fetch<T>(List<T> list, int index)
        {
            if (0 <= index && index < list.Count)
            {
                return list[index];
            }

            return default;
        }
        
        public static T FetchFirst<T>(List<T> list)
        {
            if (0 < list.Count)
            {
                return list[0];
            }

            return default;
        }
    }
}
