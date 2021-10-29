using Helab.Input.Key;
using UnityEngine;

namespace Helab.Controller
{
    public class PlayerController : AbstractController
    {
        protected override void UpdateController()
        {
            if (!gameplayContext.IsPlayable)
            {
                return;
            }
            
            UpdatePlayerInput();
        }
        
        private void UpdatePlayerInput()
        {
            var axis = gameplayContext.userInput.GetAxis("Thrust");
            var thrustDirection = TransformToCameraSpace(new Vector3(axis.x, 0f, axis.y));
            gameplayContext.PlayerInputSource.Vector3Inputs.SetInput(CharacterInputKey.ThrustDirection, thrustDirection.normalized);
            gameplayContext.PlayerInputSource.FloatInputs.SetInput(CharacterInputKey.ThrustMeasure, thrustDirection.magnitude);
            gameplayContext.PlayerInputSource.BoolInputs.SetInput(CharacterInputKey.Jump, gameplayContext.userInput.GetButtonDown("Jump"));
            gameplayContext.PlayerInputSource.BoolInputs.SetInput(CharacterInputKey.Shot, gameplayContext.userInput.GetButtonRepeat("Shot"));
        }

        private Vector3 TransformToCameraSpace(Vector3 vector)
        {
            return Quaternion.Euler(0f, gameplayContext.gameplayCamera.param.posture.eulerAngles.y, 0f) * vector;
        }
    }
}
