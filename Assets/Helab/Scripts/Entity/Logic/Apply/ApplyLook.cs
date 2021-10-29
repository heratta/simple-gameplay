using Helab.Entity.Environs.State;
using UnityEngine;

namespace Helab.Entity.Logic.Apply
{
    public class ApplyLook : AbstractApply
    {
        [SerializeField] private LookState state;

        [SerializeField] private EntityBasicParam param;
        
        public override void Apply()
        {
            param.viewDirection = state.viewDirection;
        }
    }
}
