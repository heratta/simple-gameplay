using Helab.Time;
using UnityEngine;

namespace Helab.Entity.Logic.Energy
{
    public abstract class AbstractKineticEnergy : MonoBehaviour
    {
        public bool IsEnabledUpdate { get; set; } = true;
        
        public Vector3 DeltaMovement { get; protected set; }
        
        public void ResetKineticEnergy()
        {
            DeltaMovement = Vector3.zero;
            ResetProperty();
        }

        public void UpdateKineticEnergy()
        {
            DeltaMovement = Vector3.zero;
            if (IsEnabledUpdate)
            {
                CalcKineticEnergy(AppTime.DeltaTime);
            }
        }

        protected abstract void ResetProperty();
        
        protected abstract void CalcKineticEnergy(float deltaTime);
    }
}
