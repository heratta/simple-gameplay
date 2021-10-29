using Helab.Input.Key;
using UnityEngine;

namespace Helab.Controller
{
    public class CameraController : AbstractController
    {
        protected override void UpdateController()
        {
            if (!gameplayContext.IsPlayable)
            {
                return;
            }
            
            UpdateCameraInput();
        }
        
        private void UpdateCameraInput()
        {
            var axis = gameplayContext.userInput.GetAxis("Camera");
            gameplayContext.CameraInputSource.Vector3Inputs.SetInput(CameraInputKey.RotateDirection, new Vector3(axis.x, 0f, axis.y));
            gameplayContext.CameraInputSource.BoolInputs.SetInput(CameraInputKey.LookAt, gameplayContext.userInput.GetButtonDown("LookAt"));
        }
    }
}
