using Helab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts.UI
{
    public class SimpleDialog : AbstractWidget
    {
        [SerializeField] private Button closeButton;

        private void Awake()
        {
            closeButton.onClick.AddListener(() =>
            {
                IsClosed = true;
            });
        }
    }
}
