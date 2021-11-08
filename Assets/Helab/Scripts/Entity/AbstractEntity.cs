using Helab.Entity.Environs;
using Helab.Entity.Logic;
using Helab.Entity.View;
using Helab.ObjectPool;
using UnityEngine;

namespace Helab.Entity
{
    public abstract class AbstractEntity : MonoBehaviour, IPooledObject
    {
        public EntityView view;

        public EntityBasicParam basicParam;
        
        [SerializeField] private EntityEnvirons environs;
        
        [SerializeField] private EntityLogic logic;

        public void ResetInternalState()
        {
            ResetEntity();
        }
        
        public void ManagedUpdate()
        {
            logic.UpdateLogic();
            view.UpdateView();
            
            UpdateEntity();
        }

        public virtual void SetupEntity()
        {
            view.SetupView(environs);
        }

        protected virtual void ResetEntity()
        {
            basicParam.ResetParam();
            environs.ResetEnvirons();
            logic.ResetLogic();
            view.ResetView();
        }

        protected void Kill()
        {
            basicParam.isDead = true;
        }

        protected abstract void UpdateEntity();
    }
}
