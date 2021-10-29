using System.Collections.Generic;
using Helab.Entity;
using UnityEngine;

namespace Helab.Management
{
    public class WorldUpdater : MonoBehaviour
    {
        public bool isEnabledUpdate;

        [SerializeField] private WorldDatabase worldDatabase;
        
        [SerializeField] private WorldSpawner worldSpawner;
        
        [SerializeField] private WorldSweeper worldSweeper;

        private readonly List<AbstractEntity> _deadEntities = new List<AbstractEntity>();

        public void ManagedUpdate()
        {
            if (!isEnabledUpdate)
            {
                return;
            }

            UpdateWorld();
            PostUpdateWorld();
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
                    _deadEntities.Add(entity);
                }
            }
        }

        private void PostUpdateWorld()
        {
            if (0 < _deadEntities.Count)
            {
                RemoveEntityFromWorld();
            }
        }

        private void RemoveEntityFromWorld()
        {
            foreach (var entity in _deadEntities)
            {
                if (entity.view.viewBody != null)
                {
                    worldSweeper.DestroyOrRelease(entity.view.viewBody);
                }

                if (entity.view.viewAnimation != null)
                {
                    worldSweeper.DestroyOrRelease(entity.view.viewAnimation.gameObject);
                }

                worldSweeper.DestroyOrRelease(entity.gameObject);
            }
            
            _deadEntities.Clear();
        }
    }
}
