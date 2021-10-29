using Helab.Camera;
using Helab.Management;
using UnityEngine;

namespace Helab.UI
{
    public class AbstractWidget : MonoBehaviour
    {
        [SerializeField] protected CameraLayer cameraLayer;

        [SerializeField] protected Canvas canvas;

        public void ConfigureCamera(CameraGroup cameraGroup)
        {
            var uiCamera = cameraGroup.FindCamera(cameraLayer);
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = uiCamera.unityCamera;
        }
    }
}
