using System.Collections.Generic;
using Helab.Camera;
using Helab.Controller;
using Helab.Entity.Character;
using Helab.Entity.Stage;
using Helab.Input;
using Helab.ObjectPool;
using Helab.Resource;
using Helab.UI;
using Helab.UI.Dialog;
using UnityEngine;

namespace Helab.Management
{
    public class WorldSpawner : MonoBehaviour
    {
        [SerializeField] private PoolVault poolVault;
        
        [SerializeField] private ResourceVault resourceVault;

        private readonly Queue<WorldInstance> _instances = new Queue<WorldInstance>();
        
        public void ManagedUpdate(WorldSweeper worldSweeper, WorldProvisioner worldProvisioner)
        {
            while (0 < _instances.Count)
            {
                var instance = _instances.Dequeue();
                worldSweeper.AddInstance(instance, false);
                worldProvisioner.AddComponent(instance.Component);
            }
        }

        public void SpawnCamera(AbstractCamera prefab)
        {
            GetOrInstantiate(prefab);
        }
        
        public void SpawnLight(Light prefab)
        {
            GetOrInstantiate(prefab);
        }
        
        public void SpawnUserInput(UserInput prefab)
        {
            GetOrInstantiate(prefab);
        }
        
        public void SpawnController(AbstractController prefab)
        {
            GetOrInstantiate(prefab);
        }
        
        public void SpawnWidget(AbstractWidget prefab)
        {
            GetOrInstantiate(prefab);
        }

        public void SpawnDialog(DialogInstruction instruction)
        {
            var dialog = instruction.UsePool ?
                GetOrBorrow(instruction.Prefab, 10) : GetOrInstantiate(instruction.Prefab);
            dialog.Setting = instruction.Setting;
        }
        
        public void SpawnStage(StageEntity entityPrefab, GameObject viewBodyPrefab, string entityName)
        {
            var entity = GetOrInstantiate(entityPrefab);
            entity.view.SetViewBody(GetOrInstantiate(viewBodyPrefab));
            entity.name = entityName;
        }

        public void SpawnCharacter(CharacterInstruction instruction)
        {
            if (!instruction.PrefabSet.IsValid)
            {
                instruction.PrefabSet = resourceVault.FindCharacterPrefabSet(instruction.Id);
            }
            
            var entity = GetOrBorrow(instruction.PrefabSet.entity, 10);
            entity.reference.SetPhysicalBody(GetOrBorrow(instruction.PrefabSet.physicalBody, 10));
            entity.view.SetViewBody(GetOrBorrow(instruction.PrefabSet.viewBody, 10));
            if (instruction.PrefabSet.viewAnimation != null)
            {
                entity.view.SetViewAnimation(GetOrBorrow(instruction.PrefabSet.viewAnimation, 10));
            }
            entity.IsPlayable = instruction.IsPlayable;
            if (!string.IsNullOrEmpty(instruction.Name))
            {
                entity.name = instruction.Name;
            }
            entity.transform.position = instruction.Position;
        }

        private WorldInstance GetOrInstantiateInstance(GameObject prefab)
        {
            var instance = new WorldInstance();
            if (prefab.activeInHierarchy)
            {
                instance.GameObject = prefab;
                instance.GameObject.transform.SetParent(null, false);
            }
            else
            {
                instance.GameObject = Instantiate(prefab);
            }

            _instances.Enqueue(instance);
            return instance;
        }

        private GameObject GetOrInstantiate(GameObject prefab)
        {
            var instance = GetOrInstantiateInstance(prefab);
            return instance.GameObject;
        }
        
        private T GetOrInstantiate<T>(T prefab) where T : Component
        {
            var instance = GetOrInstantiateInstance(prefab.gameObject);
            var component = instance.GameObject.GetComponent<T>();
            instance.Component = component;
            return component;
        }

        private WorldInstance GetOrBorrowInstance(GameObject prefab, int size)
        {
            var instance = new WorldInstance();
            if (prefab.activeInHierarchy)
            {
                instance.GameObject = prefab;
                instance.GameObject.transform.SetParent(null, false);
            }
            else
            {
                var pool = poolVault.FindOrCreatePool(prefab, size);
                instance.GameObject = pool.GetObject();
                instance.Pool = pool;
            }
            
            _instances.Enqueue(instance);
            return instance;
        }

        private GameObject GetOrBorrow(GameObject prefab, int size)
        {
            var instance = GetOrBorrowInstance(prefab, size);
            return instance.GameObject;
        }

        private T GetOrBorrow<T>(T prefab, int size) where T : Component
        {
            var instance = GetOrBorrowInstance(prefab.gameObject, size);
            var component = instance.GameObject.GetComponent<T>();
            instance.Component = component;
            return component;
        }
    }
}
