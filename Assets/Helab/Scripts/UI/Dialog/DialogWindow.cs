using System;
using UnityEngine;
using UnityEngine.UI;

namespace Helab.UI.Dialog
{
    public class DialogWindow : AbstractWidget
    {
        [Serializable]
        public class DialogButton
        {
            public Button button;
            
            public Text text;
        }
        
        public DialogSetting Setting;

        [SerializeField] private InteractiveBlocker blocker;
        
        [SerializeField] private Text titleText;
        
        [SerializeField] private Text messageText;
        
        [SerializeField] private DialogButton cancelButton;
        
        [SerializeField] private DialogButton okButton;

        protected override void ResetWidgetInternal()
        {
            blocker.ResetBlocker();
            ResetDialogButton(cancelButton);
            ResetDialogButton(okButton);
        }

        private void ResetDialogButton(DialogButton dialogButton)
        {
            dialogButton.text.text = "";
            dialogButton.button.onClick.RemoveAllListeners();
        }

        protected override void SetupWidgetInternal()
        {
            titleText.text = Setting.Title;
            messageText.text = Setting.Message;

            blocker.OnClick = OnClickCancel;
            SetupDialogButton(cancelButton, Setting.Cancel, OnClickCancel);
            SetupDialogButton(okButton, Setting.Ok, OnClickOk);

            widgetAnimation.StartOpenAnimation(this, null);
        }

        private void SetupDialogButton(DialogButton dialogButton, string text, Action action)
        {
            var isEnabled = !string.IsNullOrEmpty(text);
            dialogButton.button.gameObject.SetActive(isEnabled);
            if (isEnabled)
            {
                dialogButton.text.text = text;
                dialogButton.button.onClick.AddListener(() =>
                {
                    action?.Invoke();
                });
            }
        }

        private void OnClickCancel()
        {
            StartClose(Setting.OnCancel);
        }

        private void OnClickOk()
        {
            StartClose(Setting.OnOk);
        }

        private void StartClose(Action action)
        {
            action?.Invoke();
            widgetAnimation.StartCloseAnimation(this, () => IsClosed = true);
        }
    }
}
