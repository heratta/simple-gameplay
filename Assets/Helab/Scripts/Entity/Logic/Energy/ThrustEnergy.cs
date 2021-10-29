using UnityEngine;

namespace Helab.Entity.Logic.Energy
{
    public class ThrustEnergy : AbstractKineticEnergy
    {
        [SerializeField] private float thrustSpeed = 1.0f;
        
        public Vector3 ThrustDirection { get; set; }
        
        public float ThrustMeasure { get; set; }

        private static readonly Vector3 Offset = new Vector3(0f, 0.1f, 0f);

        protected override void ResetProperty()
        {
            ThrustDirection = Vector3.zero;
            ThrustMeasure = 0f;
        }

        protected override void CalcKineticEnergy(float deltaTime)
        {
            if (!Physics.Raycast(transform.position + Offset, Vector3.down, out var hit))
            {
                return;
            }
            
            var right = Vector3.Cross(hit.normal, ThrustDirection);
            var forward = Vector3.Cross(right, hit.normal);
            DeltaMovement = forward.normalized * (thrustSpeed * ThrustMeasure * deltaTime);
        }
    }
}
