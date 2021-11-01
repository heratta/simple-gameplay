using System.Collections.Generic;
using Helab.Entity;
using UnityEngine;

namespace Helab.Management
{
    public class WorldUpdater : MonoBehaviour
    {
        public bool isEnabledUpdate;

        public readonly List<AbstractEntity> DeadEntities = new List<AbstractEntity>();

        [SerializeField] private WorldDatabase worldDatabase;

        public void ManagedUpdate()
        {
            if (!isEnabledUpdate)
            {
                return;
            }

            UpdateWorld();
        }

        private void UpdateWorld()
        {
            foreach (var controller in worldDatabase.controllers)
            {
                controller.ManagedUpdate();
            }
            
            foreach (var appCamera in worldDatabase.cameraGroup.cameras)
            {
                appCamera.ManagedUpdate();
            }

            foreach (var entity in worldDatabase.entities)
            {
                entity.ManagedUpdate();
                
                if (entity.basicParam.isDead)
                {
                    DeadEntities.Add(entity);
                }
            }
        }
    }
}
