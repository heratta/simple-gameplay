using Helab.Entity.Environs;
using Helab.Entity.Logic;
using Helab.Entity.View;
using Helab.Management;
using Helab.ObjectPool;
using UnityEngine;

namespace Helab.Entity
{
    public abstract class AbstractEntity : MonoBehaviour, IPooledObject
    {
        public EntityView view;

        public EntityBasicParam basicParam;

        protected WorldSpawner WorldSpawner;
        
        [SerializeField] private EntityEnvirons environs;
        
        [SerializeField] private EntityLogic logic;

        public void ResetPooledObject()
        {
            ResetEntity();
        }

        private void ResetEntity()
        {
            basicParam.ResetParam();
            environs.ResetEnvirons();
            logic.ResetLogic();
            view.ResetView();
            
            ResetEntityInternal();
        }

        protected virtual void ResetEntityInternal()
        {
            
        }

        public void SetupEntity(WorldSpawner worldSpawner)
        {
            WorldSpawner = worldSpawner;
            view.SetupView(environs);
            
            SetupEntityInternal();
        }

        protected virtual void SetupEntityInternal()
        {
            
        }
        
        public void ManagedUpdate()
        {
            logic.UpdateLogic();
            view.UpdateView();
            
            UpdateEntity();
        }

        protected abstract void UpdateEntity();

        protected void Kill()
        {
            basicParam.isDead = true;
        }
    }
}
