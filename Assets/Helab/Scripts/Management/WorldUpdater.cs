using UnityEngine;

namespace Helab.Management
{
    public class WorldUpdater : MonoBehaviour
    {
        public bool isEnabledUpdate;

        public void ManagedUpdate(WorldDatabase worldDatabase, WorldSweeper worldSweeper)
        {
            if (!isEnabledUpdate)
            {
                return;
            }

            UpdateWorld(worldDatabase, worldSweeper);
        }

        private void UpdateWorld(WorldDatabase worldDatabase, WorldSweeper worldSweeper)
        {
            foreach (var controller in worldDatabase.controllers)
            {
                controller.ManagedUpdate();
            }
            
            foreach (var appCamera in worldDatabase.cameraGroup.cameras)
            {
                appCamera.ManagedUpdate();
            }

            foreach (var entity in worldDatabase.entityGroup.entities)
            {
                entity.ManagedUpdate();
                
                if (entity.basicParam.isDead)
                {
                    if (entity.view.viewBody != null)
                    {
                        worldSweeper.Pickup(entity.view.viewBody);
                    }
                    if (entity.view.viewAnimation != null)
                    {
                        worldSweeper.Pickup(entity.view.viewAnimation);
                    }
                    worldSweeper.Pickup(entity);
                }
            }

            foreach (var widget in worldDatabase.widgets)
            {
                if (widget.IsClosed)
                {
                    worldSweeper.Pickup(widget);
                }
            }
        }
    }
}
