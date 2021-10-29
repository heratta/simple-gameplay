using Helab.Entity.Environs.State;
using Helab.Entity.Logic.Energy;
using UnityEngine;

namespace Helab.Entity.Logic.Apply
{
    public class ApplyGravity : AbstractApply
    {
        [SerializeField] private GravityState state;
        
        [SerializeField] private GravityEnergy energy;
        
        public override void Apply()
        {
            energy.IsGrounded = state.isGrounded;
        }
    }
}
