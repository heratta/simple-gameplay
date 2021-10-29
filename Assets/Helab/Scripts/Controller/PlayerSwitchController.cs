namespace Helab.Controller
{
    public class PlayerSwitchController : AbstractController
    {
        protected override void UpdateController()
        {
            if (!gameplayContext.IsPlayable)
            {
                return;
            }
            
            UpdateSwitchInput();
        }

        private void UpdateSwitchInput()
        {
            if (gameplayContext.userInput.GetButtonDown("NextPlayer"))
            {
                gameplayContext.playerGroup.Next();
                gameplayContext.gameplayCamera.SetPlayer(gameplayContext.playerGroup.Current);
            }
            else if (gameplayContext.userInput.GetButtonDown("PrevPlayer"))
            {
                gameplayContext.playerGroup.Prev();
                gameplayContext.gameplayCamera.SetPlayer(gameplayContext.playerGroup.Current);
            }
        }
    }
}
