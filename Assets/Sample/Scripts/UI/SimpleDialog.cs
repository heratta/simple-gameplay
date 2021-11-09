using Helab.Management;
using Helab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Scripts.UI
{
    public class SimpleDialog : AbstractWidget, IJoinWorldHandler
    {
        [SerializeField] private Button closeButton;

        private WorldSweeper _worldSweeper;
        
        public void OnDidJoinWorld(WorldManagement worldManagement)
        {
            _worldSweeper = worldManagement.worldSweeper;
        }

        private void Awake()
        {
            closeButton.onClick.AddListener(() =>
            {
                _worldSweeper.Pickup(this);
            });
        }
    }
}
