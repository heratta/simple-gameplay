using UnityEngine;

namespace Helab.Entity.Character
{
    public class CharacterPhysicalBody : MonoBehaviour
    {
        public float height;

        public float radius;
        
        public Transform look;
        
        public Transform shot;

        public void SetupPhysicalBody(CharacterController characterController)
        {
            characterController.height = height;
            characterController.radius = radius;
            characterController.center = new Vector3(0f, height * 0.5f, 0f);
        }
    }
}
