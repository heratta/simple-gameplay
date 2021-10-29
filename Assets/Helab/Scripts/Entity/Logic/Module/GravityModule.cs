using Helab.Entity.Environs.State;
using UnityEngine;

namespace Helab.Entity.Logic.Module
{
    public class GravityModule : AbstractModule
    {
        [SerializeField] private CharacterController characterController;
        
        [SerializeField] private GravityState state;
        
        public override void UpdateModule()
        {
            var isGrounded = false;
            if (characterController != null)
            {
                isGrounded = characterController.isGrounded;
            }

            if (!isGrounded)
            {
                // Note: Assume zero height is the ground.
                if (transform.position.y <= 0.01f)
                {
                    isGrounded = true;
                }
            }

            state.isGrounded = isGrounded;
        }
    }
}
