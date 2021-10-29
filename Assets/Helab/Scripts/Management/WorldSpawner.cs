using Helab.Camera;
using Helab.Controller;
using Helab.Entity.Character;
using Helab.Entity.Stage;
using Helab.Input;
using Helab.ObjectPool;
using Helab.Resource;
using Helab.UI;
using UnityEngine;

namespace Helab.Management
{
    public class WorldSpawner : MonoBehaviour
    {
        [SerializeField] private WorldRoot worldRoot;
        
        [SerializeField] private WorldDatabase worldDatabase;
        
        [SerializeField] private WorldSweeper worldSweeper;
        
        [SerializeField] private PoolVault poolVault;
        
        [SerializeField] private ResourceVault resourceVault;

        [SerializeField] private GameplayContext gameplayContext;

        public void SpawnCamera(AbstractCamera prefab)
        {
            var appCamera = GetOrInstantiate(prefab);
            worldDatabase.AddComponent(worldRoot, appCamera);
        }
        
        public void SpawnLight(Light prefab)
        {
            var unityLight = GetOrInstantiate(prefab);
            worldDatabase.AddComponent(worldRoot, unityLight);
        }
        
        public void SpawnUserInput(UserInput prefab)
        {
            var input = GetOrInstantiate(prefab);
            worldDatabase.AddComponent(worldRoot, input);
        }
        
        public void SpawnController(AbstractController prefab)
        {
            var controller = GetOrInstantiate(prefab);
            controller.gameplayContext = gameplayContext;
            worldDatabase.AddComponent(worldRoot, controller);
        }

        public void SpawnWidget(AbstractWidget prefab)
        {
            var canvas = GetOrInstantiate(prefab);
            worldDatabase.AddComponent(worldRoot, canvas);
        }
        
        public StageEntity SpawnStage(StageEntity entityPrefab, GameObject viewBodyPrefab)
        {
            var entity = GetOrInstantiate(entityPrefab);
            entity.view.viewBody = GetOrInstantiate(viewBodyPrefab);
            entity.SetupStage();
            worldDatabase.AddComponent(worldRoot, entity);
            return entity;
        }

        public CharacterEntity SpawnCharacter(CharacterInstruction instruction)
        {
            if (!instruction.PrefabSet.IsValid)
            {
                instruction.PrefabSet = resourceVault.FindCharacterPrefabSet(instruction.Id);
            }
            
            var entity = GetOrBorrow(instruction.PrefabSet.entity, 10);
            entity.reference.physicalBody = GetOrBorrow(instruction.PrefabSet.physicalBody, 10);
            entity.view.viewBody = GetOrBorrow(instruction.PrefabSet.viewBody, 10);
            entity.view.viewAnimation = instruction.PrefabSet.viewAnimation != null ?
                GetOrBorrow(instruction.PrefabSet.viewAnimation, 10) : null;
            entity.SetupCharacter(instruction);
            worldDatabase.AddComponent(worldRoot, entity);
            entity.transform.position = instruction.Position;
            return entity;
        }

        private WorldInstance GetOrInstantiateInstance(GameObject prefab)
        {
            var instance = new WorldInstance
            {
                GameObject = prefab.activeInHierarchy ? prefab : Instantiate(prefab)
            };

            worldSweeper.AddInstance(instance, false);
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
            }
            else
            {
                var pool = poolVault.FindOrCreatePool(prefab, size);
                instance.GameObject = pool.GetObject();
                instance.Pool = pool;
            }
            
            worldSweeper.AddInstance(instance, false);
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
