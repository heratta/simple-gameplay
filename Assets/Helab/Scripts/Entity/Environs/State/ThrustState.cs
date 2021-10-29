using UnityEngine;

namespace Helab.Entity.Environs.State
{
    public class ThrustState : AbstractState
    {
        public bool isEnabledUpdate;

        public Vector3 thrustDirection;

        public float thrustMeasure;
        
        public float adjustmentRateOfThrustMeasure;

        public override void ResetState()
        {
            isEnabledUpdate = false;
            thrustDirection = Vector3.zero;
            thrustMeasure = 0f;
            adjustmentRateOfThrustMeasure = 0f;
        }
    }
}
