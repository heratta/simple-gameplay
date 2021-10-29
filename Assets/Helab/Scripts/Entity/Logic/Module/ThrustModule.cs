using Helab.Entity.Environs.State;
using Helab.Input;
using Helab.Input.Key;
using UnityEngine;

namespace Helab.Entity.Logic.Module
{
    public class ThrustModule : AbstractModule
    {
        [SerializeField] private InputSource inputSource;
        
        [SerializeField] private ThrustState state;
        
        public override void UpdateModule()
        {
            var thrustDirection = inputSource.Vector3Inputs.GetInput(CharacterInputKey.ThrustDirection);
            state.isEnabledUpdate = 0f < thrustDirection.magnitude;
            state.thrustDirection = thrustDirection;
            state.thrustMeasure = inputSource.FloatInputs.GetInput(CharacterInputKey.ThrustMeasure);
            state.adjustmentRateOfThrustMeasure = 1.0f;
        }
    }
}
