using Helab.Camera;
using Helab.Input;
using UnityEngine;

namespace Helab.Management
{
    public class GameplayContext : MonoBehaviour
    {
        public UserInput userInput;
            
        public GameplayCamera gameplayCamera;
        
        public PlayerGroup playerGroup;
        
        public bool IsPlayable => userInput != null && gameplayCamera != null && playerGroup.Current != null;

        public InputSource CameraInputSource => gameplayCamera.param.inputSource;
        
        public InputSource PlayerInputSource => playerGroup.Current.inputSource;

        public void Reset()
        {
            userInput = null;
            gameplayCamera = null;
            playerGroup.Reset();
        }
    }
}
