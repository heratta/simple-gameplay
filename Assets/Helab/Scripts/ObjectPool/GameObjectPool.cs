using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Helab.ObjectPool
{
    public class GameObjectPool
    {
        private readonly IObjectPool<GameObject> _pool;

        private readonly GameObject _prefab;

        private readonly Transform _parent;

        private readonly Dictionary<int, GameObject> _activeDict = new Dictionary<int, GameObject>();

        public GameObjectPool(GameObject prefab, Transform parent, int size)
        {
            _prefab = prefab;
            _parent = parent;
            
            _pool = new ObjectPool<GameObject>(
                CreateFunc,
                OnGetObject,
                OnReleaseObject,
                OnDestroyObject,
                true,
                size,
                size);
        }

        public bool Contains(GameObject go)
        {
            return _activeDict.ContainsKey(go.GetInstanceID());
        }

        public GameObject GetObject()
        {
            return _pool.Get();
        }

        public T GetObject<T>()
        {
            var go = GetObject();
            return go.GetComponent<T>();
        }
        
        public void ReleaseObject(GameObject go)
        {
            go.transform.SetParent(_parent, false);
            _pool.Release(go);
        }

        private GameObject CreateFunc()
        {
            return Object.Instantiate(_prefab, _parent, false);
        }

        private void OnGetObject(GameObject go)
        {
            go.gameObject.SetActive(true);
            _activeDict.Add(go.GetInstanceID(), go);
        }

        private void OnReleaseObject(GameObject go)
        {
            go.gameObject.SetActive(false);
            _activeDict.Remove(go.GetInstanceID());
        }
        
        private static void OnDestroyObject(GameObject obj)
        {
            Object.Destroy(obj.gameObject);
        }
    }
}
