using System.Collections;
using System.Collections.Generic;
using Helab.Controller;
using Helab.Entity;
using Helab.Management.Context;
using Helab.Management.Group;
using Helab.UI;
using UnityEngine;

namespace Helab.Management
{
    public class WorldProvisioner : MonoBehaviour
    {
        public bool isEnabledUpdate;
        
        public bool IsEmpty => _provisioningCount <= 0;
        
        [SerializeField] private WorldSpawner worldSpawner;
        
        [SerializeField] private CameraGroup cameraGroup;

        [SerializeField] private GameplayContext gameplayContext;

        private readonly Queue<Component> _components = new Queue<Component>();

        private readonly Queue<Component> _componentsInReady = new Queue<Component>();

        private int _provisioningCount;

        public void AddComponent(Component component)
        {
            _components.Enqueue(component);
            _provisioningCount++;
        }

        public void ManagedUpdate(WorldManagement worldManagement)
        {
            if (!isEnabledUpdate)
            {
                return;
            }
            
            UpdateProvisioning();
            AddComponentsToWorld(worldManagement);
        }

        private void UpdateProvisioning()
        {
            while (0 < _components.Count)
            {
                var component = _components.Dequeue();
                switch (component)
                {
                case AbstractController controller:
                    ProvisionController(controller);
                    break;
                case AbstractEntity entity:
                    ProvisionEntity(entity);
                    break;
                case AbstractWidget widget:
                    StartCoroutine(ProvisionWidget(widget));
                    break;
                default:
                    FinishProvisioning(component);
                    break;
                }
            }
        }

        private void AddComponentsToWorld(WorldManagement worldManagement)
        {
            while (0 < _componentsInReady.Count)
            {
                var component = _componentsInReady.Dequeue();
                worldManagement.worldDatabase.AddComponent(component);
                (component as IJoinWorldHandler)?.OnDidJoinWorld(worldManagement);
            } 
        }

        private void FinishProvisioning(Component component)
        {
            _componentsInReady.Enqueue(component);
            --_provisioningCount;
        }

        private void ProvisionController(AbstractController controller)
        {
            controller.gameplayContext = gameplayContext;
            FinishProvisioning(controller);
        }

        private void ProvisionEntity(AbstractEntity entity)
        {
            entity.SetupEntity(worldSpawner);
            FinishProvisioning(entity);
        }

        private IEnumerator ProvisionWidget(AbstractWidget widget)
        {
            while (true)
            {
                var uiCamera = cameraGroup.FindCamera(widget.cameraLayer);
                if (uiCamera != null)
                {
                    widget.SetupWidget(worldSpawner, uiCamera);
                    FinishProvisioning(widget);
                    break;
                }

                yield return null;
            }
        }
    }
}
