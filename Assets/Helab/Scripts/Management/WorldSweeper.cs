using System.Collections.Generic;
using Helab.Entity;
using Helab.Helper;
using UnityEngine;

namespace Helab.Management
{
    public class WorldSweeper : MonoBehaviour
    {
        [SerializeField] private WorldDatabase worldDatabase;
        
        private readonly Dictionary<int, WorldInstance> _instances = new Dictionary<int, WorldInstance>();
        
        private readonly Dictionary<int, WorldInstance> _persistentInstances = new Dictionary<int, WorldInstance>();

        public void AddInstance(WorldInstance instance, bool isPersistent)
        {
            if (isPersistent)
            {
                _persistentInstances.Add(instance.Key, instance);
            }
            else
            {
                _instances.Add(instance.Key, instance);
            }
        }

        public void SetPersistentInstance(Component component)
        {
            SetPersistentInstance(component.gameObject);
        }

        public void SetPersistentInstance(GameObject go)
        {
            Displace.Do(_instances, go.GetInstanceID(), _persistentInstances);
        }

        public void SetNormalInstance(Component component)
        {
            SetNormalInstance(component.gameObject);
        }

        public void SetNormalInstance(GameObject go)
        {
            Displace.Do(_persistentInstances, go.GetInstanceID(), _instances);
        }

        public void DestroyOrRelease(GameObject go)
        {
            var key = go.GetInstanceID();
            var instance = _instances[key];
            DestroyOrRelease(instance);
            _instances.Remove(key);
        }

        public void Cleanup()
        {
            foreach (var kvp in _instances)
            {
                DestroyOrRelease(kvp.Value);
            }
            
            _instances.Clear();
        }

        private void DestroyOrRelease(WorldInstance instance)
        {
            worldDatabase.RemoveComponent(instance.Component);
            
            if (instance.Pool != null)
            {
                if (instance.Component is AbstractEntity entity)
                {
                    entity.ResetEntity();
                }
                
                instance.Pool.ReleaseObject(instance.GameObject);
            }
            else
            {
                Destroy(instance.GameObject);
            }
        }
    }
}
