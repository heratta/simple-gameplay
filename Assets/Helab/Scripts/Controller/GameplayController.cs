using System.Collections;
using Helab.Camera;
using Helab.Helper;
using Helab.Management;
using UnityEngine;

namespace Helab.Controller
{
    public class GameplayController : AbstractController, IJoinWorldHandler
    {
        public void OnDidJoinWorld(WorldManagement worldManagement)
        {
            StartCoroutine(SetupGameplay(worldManagement));
        }
        
        protected override void UpdateController()
        {
            
        }

        private IEnumerator SetupGameplay(WorldManagement worldManagement)
        {
            yield return new WaitUntil(() => worldManagement.worldProvisioner.IsEmpty);
            
            gameplayContext.userInput = GetOrDefault.FetchFirst(worldManagement.worldDatabase.userInputs);
            gameplayContext.gameplayCamera = worldManagement.worldDatabase.cameraGroup.FindCamera<GameplayCamera>();
            if (!worldManagement.worldDatabase.playerGroup.IsEmpty && gameplayContext.gameplayCamera != null)
            {
                gameplayContext.gameplayCamera.SetPlayer(worldManagement.worldDatabase.playerGroup.Current);
            }
        }
    }
}
