using UnityEngine;

namespace Helab.Entity.Logic
{
    public class EntityLogic : MonoBehaviour
    {
        [SerializeField] private EntityModular modular;
        
        [SerializeField] private EntityApplier applier;
        
        [SerializeField] private EntityMovement movement;

        public void ResetLogic()
        {
            modular.ResetModular();
            movement.ResetMovement();
        }
        
        public void UpdateLogic()
        {
            if (modular != null)
            {
                modular.UpdateModular();
            }

            if (applier != null)
            {
                applier.UpdateApplier();
            }

            if (movement != null)
            {
                movement.UpdateMovement();
            }
        }
    }
}
