using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helab.Management
{
    public class LoadManagementScene : MonoBehaviour
    {
        private static bool _didLoadScene;

        private static WorldManagement _management;

        private bool _isEnabledUpdate = true;

        public static void OnDidLoadManagementScene(WorldManagement management)
        {
            _management = management;
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
            if (_management == null || !_isEnabledUpdate)
            {
                return;
            }
            
            var components = GetComponents<MonoBehaviour>();
            foreach (var c in components)
            {
                if (c is ILoadManagementScene i)
                {
                    i.OnDidLoadManagementScene(_management);
                }
            }
            
            _isEnabledUpdate = false;
        }
    }
}
