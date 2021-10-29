using System.Collections.Generic;
using Helab.Camera;
using UnityEngine;

namespace Helab.Management
{
    public class CameraGroup : MonoBehaviour
    {
        public List<AbstractCamera> cameras;

        public void AddCamera(AbstractCamera appCamera)
        {
            cameras.Add(appCamera);
        }

        public void RemoveCamera(AbstractCamera appCamera)
        {
            cameras.Remove(appCamera);
        }

        public AbstractCamera FindCamera(CameraLayer cameraLayer)
        {
            foreach (var appCamera in cameras)
            {
                if (appCamera.cameraLayer == cameraLayer)
                {
                    return appCamera;
                }
            }
            
            return null;
        }

        public T FindCamera<T>() where T : AbstractCamera
        {
            foreach (var appCamera in cameras)
            {
                if (appCamera is T cam)
                {
                    return cam;
                }
            }
            
            return null;
        }
    }
}
