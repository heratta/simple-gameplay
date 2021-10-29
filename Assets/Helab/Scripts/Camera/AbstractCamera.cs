using UnityEngine;

namespace Helab.Camera
{
    public abstract class AbstractCamera : MonoBehaviour
    {
        public CameraLayer cameraLayer;

        public int depth;

        public UnityEngine.Camera unityCamera;

        private void Awake()
        {
            unityCamera.depth = depth;
        }
        
        public void ManagedUpdate()
        {
            UpdateCamera();
        }

        protected abstract void UpdateCamera();
    }
}
