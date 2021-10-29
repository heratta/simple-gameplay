using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helab.ObjectPool
{
    public class PoolVault : MonoBehaviour
    {
        private readonly Dictionary<int, GameObjectPool> _pools = new Dictionary<int, GameObjectPool>();

        public GameObjectPool FindOrCreatePool(GameObject prefab, int size)
        {
            _pools.TryGetValue(prefab.GetInstanceID(), out var pool);
            if (pool == null)
            {
                pool = new GameObjectPool(prefab, transform, size);
                _pools.Add(prefab.GetInstanceID(), pool);
            }
            
            return pool;
        }

        public GameObjectPool FindPoolByInstance(GameObject go)
        {
            return (from kvp in _pools where kvp.Value.Contains(go) select kvp.Value).FirstOrDefault();
        }
    }
}
