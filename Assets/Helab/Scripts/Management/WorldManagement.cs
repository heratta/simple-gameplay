using Helab.Management.Context;
using UnityEngine;

namespace Helab.Management
{
    public class WorldManagement : MonoBehaviour
    {
        public WorldDatabase worldDatabase;

        public WorldSpawner worldSpawner;
        
        public WorldProvisioner worldProvisioner;
        
        public WorldSweeper worldSweeper;

        public WorldUpdater worldUpdater;

        public GameplayContext gameplayContext;

        public void CleanupInWorld()
        {
            worldSweeper.PickupAll();
        }

        public void OnStartConfigure()
        {
            worldProvisioner.isEnabledUpdate = false;
            worldUpdater.isEnabledUpdate = false;
        }

        public void OnDidCompleteConfigure()
        {
            worldProvisioner.isEnabledUpdate = true;
            worldUpdater.isEnabledUpdate = true;
        }
        
        private void Awake()
        {
            LoadManagementScene.OnDidLoadManagementScene(this);
        }

        private void Update()
        {
            worldSweeper.ManagedUpdate(worldDatabase);
            worldSpawner.ManagedUpdate(worldSweeper, worldProvisioner);
            worldProvisioner.ManagedUpdate(this);
            worldUpdater.ManagedUpdate(worldDatabase, worldSweeper);
        }
    }
}
