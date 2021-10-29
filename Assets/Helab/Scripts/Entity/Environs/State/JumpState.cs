using UnityEngine;

namespace Helab.Entity.Environs.State
{
    public class JumpState : AbstractState
    {
        public bool isEnabledUpdate;

        public float jumpSpeed;

        public Vector3 jumpDirection;

        public override void ResetState()
        {
            isEnabledUpdate = false;
            jumpSpeed = 0f;
            jumpDirection = Vector3.zero;
        }
    }
}
