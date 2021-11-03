using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Helab.Management;
using UnityEngine;

namespace Helab.Configure
{
    [RequireComponent(typeof(LoadManagementScene))]
    public class WorldConfigure : MonoBehaviour, ILoadManagementScene
    {
        [SerializeField] private List<Make> makes;
        
        private WorldManagement _worldManagement;
        
        public void OnDidLoadManagementScene(WorldManagement worldManagement)
        {
            _worldManagement = worldManagement;
        }

        private void Awake()
        {
            if (makes.Count <= 0)
            {
                makes.AddRange(GetComponentsInChildren<Make>());
            }
        }

        private void Start()
        {
            StartCoroutine(MakeWorld());
        }

        private IEnumerator MakeWorld()
        {
            yield return new WaitUntil(() => _worldManagement != null);

            _worldManagement.OnStartConfigure();
            
#if UNITY_EDITOR
            yield return null;
            _worldManagement.worldDatabase.worldRoot.DumpChildCount();
#endif
            
            foreach (var make in makes)
            {
                make.StartMake(_worldManagement.worldSpawner);
            }

            yield return new WaitUntil(IsCompletedMake);
            
            OnDidCompleteConfigure(_worldManagement);
            _worldManagement.OnDidCompleteConfigure();
            
            gameObject.SetActive(false);
        }

        private bool IsCompletedMake()
        {
            return makes.All(make => make.IsCompleted);
        }

        protected virtual void OnDidCompleteConfigure(WorldManagement worldManagement)
        {
            
        }
    }
}
