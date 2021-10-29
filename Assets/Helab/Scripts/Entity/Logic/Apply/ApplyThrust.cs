using Helab.Entity.Environs.State;
using Helab.Entity.Logic.Energy;
using UnityEngine;

namespace Helab.Entity.Logic.Apply
{
    public class ApplyThrust : AbstractApply
    {
        [SerializeField] private ThrustState state;
        
        [SerializeField] private ThrustEnergy energy;
        
        public override void Apply()
        {
            energy.IsEnabledUpdate = state.isEnabledUpdate;
            energy.ThrustDirection = state.thrustDirection;
            energy.ThrustMeasure = state.thrustMeasure * state.adjustmentRateOfThrustMeasure;
        }
    }
}
