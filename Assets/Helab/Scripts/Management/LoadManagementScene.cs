using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helab.Management
{
    public class LoadManagementScene : MonoBehaviour
    {
        private static bool _didStartLoadScene;

        private static WorldManagement _worldManagement;

        public static void OnDidLoadManagementScene(WorldManagement worldManagement)
        {
            _worldManagement = worldManagement;
        }
        
        private void Start()
        {
            if (!_didStartLoadScene)
            {
                SceneManager.LoadScene("WorldManagement", LoadSceneMode.Additive);
                _didStartLoadScene = true;
            }
            
            StartCoroutine(WaitLoadManagementScene());
        }

        private IEnumerator WaitLoadManagementScene()
        {
            yield return new WaitUntil(() => _worldManagement != null);
            
            InvokeOnDidLoadManagementScene();
        }

        private void InvokeOnDidLoadManagementScene()
        {
            var behaviours = GetComponents<MonoBehaviour>();
            foreach (var behaviour in behaviours)
            {
                (behaviour as ILoadSceneHandler)?.OnDidLoadScene(_worldManagement);
            }
        }
    }
}
