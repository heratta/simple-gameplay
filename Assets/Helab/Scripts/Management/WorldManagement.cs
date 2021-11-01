using UnityEngine;

namespace Helab.Management
{
    public class WorldManagement : MonoBehaviour
    {
        public WorldDatabase worldDatabase;

        public WorldSpawner worldSpawner;
        
        public WorldSweeper worldSweeper;

        public WorldUpdater worldUpdater;

        public GameplayContext gameplayContext;

        public void OnStartConfigure()
        {
            worldSweeper.Cleanup();
            worldUpdater.isEnabledUpdate = false;
        }

        public void OnDidCompleteConfigure()
        {
            worldUpdater.isEnabledUpdate = true;
            foreach (var widget in worldDatabase.widgets)
            {
                widget.ConfigureCamera(worldDatabase.cameraGroup);
            }
        }
        
        private void Awake()
        {
            LoadManagementScene.OnDidLoadManagementScene(this);
        }

        private void Update()
        {
            worldUpdater.ManagedUpdate();
            if (0 < worldUpdater.DeadEntities.Count)
            {
                worldSweeper.RemoveEntityFromWorld(worldUpdater.DeadEntities);
            }
        }
    }
}
