using Helab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts.UI
{
    public class SimpleButton : AbstractWidget
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(() => Debug.Log("Click simple button"));
        }
    }
}
