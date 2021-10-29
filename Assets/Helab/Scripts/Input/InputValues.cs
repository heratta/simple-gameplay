using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

namespace Helab.Input
{
    public class InputValues<TValue>
    {
        private Dictionary<int, TValue> _valueDict;

        public void Clear()
        {
            _valueDict?.Clear();
        }

        public bool HasInput<TKey>(TKey enumKey) where TKey : Enum
        {
            return _valueDict?.ContainsKey(ToInt(enumKey)) ?? false;
        }
        
        public TValue GetInput<TKey>(TKey enumKey) where TKey : Enum
        {
            TValue result = default;
            _valueDict?.TryGetValue(ToInt(enumKey), out result);
            return result;
        }
        
        public void SetInput<TKey>(TKey enumKey, TValue value) where TKey : Enum
        {
            _valueDict ??= new Dictionary<int, TValue>();

            var key = ToInt(enumKey);
            if (_valueDict.ContainsKey(key))
            {
                _valueDict[key] = value;
            }
            else
            {
                _valueDict.Add(key, value);
            }
        }

        private static int ToInt<TKey>(TKey enumKey) where TKey : Enum
        {
            return UnsafeUtility.As<TKey, int>(ref enumKey);
        }
    }
}
