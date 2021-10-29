using Helab.Entity.Environs.State;
using Helab.Time;
using UnityEngine;

namespace Helab.Entity.Logic.Module
{
    public class TurnAroundModule : AbstractModule
    {
        [SerializeField] private float turnSpeed = 1.0f;
        
        [SerializeField] private LookState lookState;

        [SerializeField] private ThrustState thrustState;

        public override void UpdateModule()
        {
            if (thrustState.isEnabledUpdate)
            {
                lookState.targetDirection = thrustState.thrustDirection;
            }
            
            if (0.001f < Vector3.Distance(lookState.viewDirection, lookState.targetDirection))
            {
                lookState.viewDirection = Vector3.Lerp(lookState.viewDirection, lookState.targetDirection, turnSpeed * AppTime.DeltaTime);
            }
        }
    }
}
