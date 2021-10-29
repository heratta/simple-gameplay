using Helab.Entity.Environs.State;
using Helab.Entity.Logic.Energy;
using UnityEngine;

namespace Helab.Entity.Logic.Apply
{
    public class ApplyJump : AbstractApply
    {
        [SerializeField] private JumpState state;
        
        [SerializeField] private JumpEnergy energy;
        
        public override void Apply()
        {
            energy.IsEnabledUpdate = state.isEnabledUpdate;
            energy.jumpSpeed = state.jumpSpeed;
            energy.JumpDirection = state.jumpDirection;
        }
    }
}
