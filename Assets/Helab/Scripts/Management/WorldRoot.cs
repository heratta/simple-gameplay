using UnityEngine;

namespace Helab.Management
{
    public class WorldRoot : MonoBehaviour
    {
        public Transform cameraRoot;
        
        public Transform lightRoot;
        
        public Transform inputRoot;
        
        public Transform controllerRoot;
        
        public Transform uiRoot;
        
        public Transform stageRoot;
        
        public Transform characterRoot;

        public void DeployToCameraRoot(GameObject go)
        {
            DeployToRoot(cameraRoot, go.transform);
        }
        
        public void DeployToLightRoot(GameObject go)
        {
            DeployToRoot(lightRoot, go.transform);
        }
        
        public void DeployToControllerRoot(GameObject go)
        {
            DeployToRoot(controllerRoot, go.transform);
        }
        
        public void DeployToInputRoot(GameObject go)
        {
            DeployToRoot(inputRoot, go.transform);
        }
        
        public void DeployToUIRoot(GameObject go)
        {
            DeployToRoot(uiRoot, go.transform);
        }
        
        public void DeployToStageRoot(GameObject go)
        {
            DeployToRoot(stageRoot, go.transform);
        }
        
        public void DeployToCharacterRoot(GameObject go)
        {
            DeployToRoot(characterRoot, go.transform);
        }

        private void DeployToRoot(Transform parent, Transform child)
        {
            child.SetParent(parent, false);
        }
        
#if UNITY_EDITOR
        public void DumpChildCount()
        {
            var log = "";
            foreach (Transform child in transform)
            {
                if (0 < child.transform.childCount)
                {
                    log += $"{child.name}: childCount={child.transform.childCount}\n";
                }
            }

            if (string.IsNullOrEmpty(log))
            {
                log = "WorldRoot is empty.";
            }

            Debug.Log(log);
        }
#endif
    }
}
