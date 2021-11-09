using Helab.Management;
using Helab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts.UI
{
    public class SimpleButton : AbstractWidget, IJoinWorldHandler
    {
        [SerializeField] private Button button;
        
        [SerializeField] private AbstractWidget dialogPrefab;

        private WorldSpawner _worldSpawner;

        public void OnDidJoinWorld(WorldManagement worldManagement)
        {
            _worldSpawner = worldManagement.worldSpawner;
        }

        private void Awake()
        {
            button.onClick.AddListener(() =>
            {
                _worldSpawner.SpawnWidget(dialogPrefab);
            });
        }
    }
}
