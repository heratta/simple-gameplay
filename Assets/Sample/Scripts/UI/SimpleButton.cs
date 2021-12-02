using Helab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts.UI
{
    public class SimpleButton : AbstractWidget
    {
        [SerializeField] private Button button;
        
        [SerializeField] private AbstractWidget dialogPrefab;

        private void Awake()
        {
            button.onClick.AddListener(() =>
            {
                WorldSpawner.SpawnWidget(dialogPrefab);
            });
        }
    }
}
