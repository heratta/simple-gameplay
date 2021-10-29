using UnityEngine;

namespace Helab.Entity.Logic.Energy
{
    public class GravityEnergy : AbstractKineticEnergy
    {
        [SerializeField] private float gravitationalAcceleration = 9.8f;

        private float _gravitySpeed;

        public bool IsGrounded { get; set; }

        protected override void ResetProperty()
        {
            _gravitySpeed = 0f;
            IsGrounded = false;
        }

        protected override void CalcKineticEnergy(float deltaTime)
        {
            if (IsGrounded)
            {
                _gravitySpeed = 0f;
            }
            else
            {
                _gravitySpeed += gravitationalAcceleration * deltaTime;
                DeltaMovement = Vector3.down * (_gravitySpeed * deltaTime);
            }
        }
    }
}
