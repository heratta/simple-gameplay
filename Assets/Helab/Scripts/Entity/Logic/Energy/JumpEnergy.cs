using UnityEngine;

namespace Helab.Entity.Logic.Energy
{
    public class JumpEnergy : AbstractKineticEnergy
    {
        public float jumpSpeed = 1.0f;
        
        public Vector3 JumpDirection { get; set; }
        
        protected override void ResetProperty()
        {
            jumpSpeed = 1f;
            JumpDirection = Vector3.zero;
        }

        protected override void CalcKineticEnergy(float deltaTime)
        {
            DeltaMovement = JumpDirection * (jumpSpeed * deltaTime);
        }
    }
}
