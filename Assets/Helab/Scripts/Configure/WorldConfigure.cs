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
        
        private WorldManagement _management;
        
        public void OnDidLoadManagementScene(WorldManagement management)
        {
            _management = management;
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
            yield return new WaitUntil(() => _management != null);

            _management.OnStartConfigure();
            
#if UNITY_EDITOR
            yield return null;
            _management.worldRoot.DumpChildCount();
#endif
            
            foreach (var make in makes)
            {
                make.worldSpawner = _management.worldSpawner;
                make.StartMake();
            }

            yield return new WaitUntil(IsCompletedMake);
            
            OnDidCompleteConfigure(_management);
            _management.OnDidCompleteConfigure();
            
            gameObject.SetActive(false);
        }

        private bool IsCompletedMake()
        {
            return makes.All(make => make.IsCompleted);
        }

        protected virtual void OnDidCompleteConfigure(WorldManagement management)
        {
            
        }
    }
}
