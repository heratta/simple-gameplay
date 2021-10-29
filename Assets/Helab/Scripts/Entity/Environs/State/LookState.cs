using UnityEngine;

namespace Helab.Entity.Environs.State
{
    public class LookState : AbstractState
    {
        public Vector3 targetDirection;
        
        public Vector3 viewDirection;

        private void Awake()
        {
            ResetState();
        }

        public override void ResetState()
        {
            targetDirection = Vector3.forward;
            viewDirection = Vector3.forward;
        }
    }
}
