using Helab.Entity.Environs;
using Helab.Entity.Logic;
using Helab.Entity.View;
using UnityEngine;

namespace Helab.Entity
{
    public abstract class AbstractEntity : MonoBehaviour
    {
        public EntityView view;

        public EntityBasicParam basicParam;
        
        [SerializeField] private EntityEnvirons environs;
        
        [SerializeField] private EntityLogic logic;

        public virtual void ResetEntity()
        {
            basicParam.ResetParam();
            environs.ResetEnvirons();
            logic.ResetLogic();
            view.ResetView();
        }
        
        public void ManagedUpdate()
        {
            logic.UpdateLogic();
            view.UpdateView();
            
            UpdateEntity();
        }

        protected void SetupEntity()
        {
            view.SetupView();
        }

        protected void Kill()
        {
            basicParam.isDead = true;
        }

        protected abstract void UpdateEntity();
    }
}
