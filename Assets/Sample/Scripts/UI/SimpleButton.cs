using Helab.UI;
using Helab.UI.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts.UI
{
    public class SimpleButton : AbstractWidget
    {
        [SerializeField] private Button button;
        
        [SerializeField] private DialogWindow dialogPrefab;

        private void Awake()
        {
            button.onClick.AddListener(OpenDialog);
        }
        
        private void OpenDialog()
        {
            var instruction = new DialogInstruction
            {
                UsePool = true,
                Prefab = dialogPrefab,
                Setting = new DialogSetting
                {
                    Title = "Title",
                    Message = "Message\nMessage\nMessage",
                    Cancel = "Cancel",
                    Ok = "OK",
                    OnCancel = () => Debug.Log("Cancel"),
                    OnOk = () => Debug.Log("Ok"),
                },
            };
            WorldSpawner.SpawnDialog(instruction);
        }
    }
}
