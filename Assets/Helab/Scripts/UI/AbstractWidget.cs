using Helab.Camera;
using Helab.Management;
using Helab.ObjectPool;
using UnityEngine;

namespace Helab.UI
{
    public abstract class AbstractWidget : MonoBehaviour, IPooledObject
    {
        public bool IsClosed { get; protected set; }
        
        public CameraLayer cameraLayer;

        public Canvas canvas;
        
        public CanvasGroup canvasGroup;
        
        public Transform content;
        
        [SerializeField] protected WidgetAnimation widgetAnimation;

        protected WorldSpawner WorldSpawner;

        private void Awake()
        {
            ResetWidget();
        }

        public void ResetPooledObject()
        {
            ResetWidget();
        }

        private void ResetWidget()
        {
            IsClosed = false;
            
            canvas.enabled = false;
            canvas.worldCamera = null;
            
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1f;
            }
            
            content.localPosition = Vector3.zero;
            
            ResetWidgetInternal();
        }
        
        protected virtual void ResetWidgetInternal()
        {
            
        }

        public void SetupWidget(WorldSpawner worldSpawner, AbstractCamera uiCamera)
        {
            WorldSpawner = worldSpawner;
            
            canvas.enabled = true;
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = uiCamera.unityCamera;
            
            SetupWidgetInternal();
        }

        protected virtual void SetupWidgetInternal()
        {
            
        }
    }
}
