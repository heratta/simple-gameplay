using Helab.Input;
using UnityEngine;

namespace Helab.Entity.Character
{
    public class CharacterEntity : AbstractEntity
    {
        public CharacterReference reference;

        public InputSource inputSource;

        public bool IsPlayable { get; set; }
        
        [SerializeField] private CharacterController characterController;

        protected override void ResetEntityInternal()
        {
            reference.ResetReference();
        }

        protected override void SetupEntityInternal()
        {
            reference.physicalBody.SetupPhysicalBody(characterController);
        }

        protected override void UpdateEntity()
        {
            Move(basicParam.deltaMovement);
            Look(basicParam.viewDirection);
        }

        private void Move(Vector3 deltaMovement)
        {
            characterController.Move(deltaMovement);
        }

        private void Look(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
