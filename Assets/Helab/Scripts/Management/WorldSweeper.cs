using System.Collections.Generic;
using Helab.Helper;
using Helab.ObjectPool;
using UnityEngine;

namespace Helab.Management
{
    public class WorldSweeper : MonoBehaviour
    {
        public int InstanceCount => _instances.Count;
        
        private readonly Dictionary<int, WorldInstance> _instances = new Dictionary<int, WorldInstance>();
        
        private readonly Dictionary<int, WorldInstance> _instancesInKeep = new Dictionary<int, WorldInstance>();

        private readonly Queue<WorldInstance> _instancesInPickup = new Queue<WorldInstance>();

        public void AddInstance(WorldInstance instance, bool isPersistent)
        {
            if (isPersistent)
            {
                _instancesInKeep.Add(instance.Key, instance);
            }
            else
            {
                _instances.Add(instance.Key, instance);
            }
        }

        public void Pickup(Component component)
        {
            Pickup(component.gameObject);
        }

        public void Pickup(GameObject go)
        {
            var key = go.GetInstanceID();
            if (_instances.TryGetValue(key, out var instance))
            {
                _instancesInPickup.Enqueue(instance);
            }
        }

        public void PickupAll()
        {
            foreach (var kvp in _instances)
            {
                Pickup(kvp.Value.GameObject);
            }
        }

        public void SetPersistentInstance(Component component)
        {
            SetPersistentInstance(component.gameObject);
        }

        public void SetPersistentInstance(GameObject go)
        {
            Displace.Do(go.GetInstanceID(), _instances, _instancesInKeep);
        }

        public void SetNormalInstance(Component component)
        {
            SetNormalInstance(component.gameObject);
        }

        public void SetNormalInstance(GameObject go)
        {
            Displace.Do(go.GetInstanceID(), _instancesInKeep, _instances);
        }

        public void ManagedUpdate(WorldDatabase worldDatabase)
        {
            while (0 < _instancesInPickup.Count)
            {
                var instance = _instancesInPickup.Dequeue();
                if (!_instances.ContainsKey(instance.Key))
                {
                    continue;
                }

                if (instance.Component != null)
                {
                    worldDatabase.RemoveComponent(instance.Component);
                }
                
                if (instance.Pool != null)
                {
                    if (instance.Component is IPooledObject pooled)
                    {
                        pooled.ResetInternalState();
                    }
                    instance.Pool.ReleaseObject(instance.GameObject);
                }
                else
                {
                    Destroy(instance.GameObject);
                }
            
                _instances.Remove(instance.Key);
            }
        }
    }
}
