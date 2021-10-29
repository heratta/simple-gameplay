using UnityEngine;

namespace Helab.Entity
{
    public class EntityBasicParam : MonoBehaviour
    {
        public bool isDead;
        
        public float lifeTime;
        
        public Vector3 deltaMovement;

        public Vector3 viewDirection;

        public bool isExpiredLife;

        public void ResetParam()
        {
            isDead = false;
            lifeTime = 0f;
            deltaMovement = Vector3.zero;
            viewDirection = Vector3.zero;
            isExpiredLife = false;
        }
    }
}
