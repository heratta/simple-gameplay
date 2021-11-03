using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helab.Management
{
    public class LoadManagementScene : MonoBehaviour
    {
        private static bool _didLoadScene;

        private static WorldManagement _worldManagement;

        private bool _isEnabledUpdate = true;

        public static void OnDidLoadManagementScene(WorldManagement worldManagement)
        {
            _worldManagement = worldManagement;
        }
        
        private void Start()
        {
            if (!_didLoadScene)
            {
                SceneManager.LoadScene("WorldManagement", LoadSceneMode.Additive);
                _didLoadScene = true;
            }
        }

        private void Update()
        {
            if (_worldManagement == null || !_isEnabledUpdate)
            {
                return;
            }
            
            var components = GetComponents<MonoBehaviour>();
            foreach (var c in components)
            {
                if (c is ILoadManagementScene i)
                {
                    i.OnDidLoadManagementScene(_worldManagement);
                }
            }
            
            _isEnabledUpdate = false;
        }
    }
}
