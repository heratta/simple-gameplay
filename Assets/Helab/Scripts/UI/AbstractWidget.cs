using Helab.Camera;
using UnityEngine;

namespace Helab.UI
{
    public class AbstractWidget : MonoBehaviour
    {
        public CameraLayer cameraLayer;

        [SerializeField] protected Canvas canvas;

        public void SetupWidget(AbstractCamera uiCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = uiCamera.unityCamera;
        }
    }
}
