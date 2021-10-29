using Helab.Input;
using UnityEngine;

namespace Helab.Entity.Character
{
    public class CharacterEntity : AbstractEntity
    {
        public CharacterReference reference;

        public InputSource inputSource;
        
        public bool IsPlayable { get; private set; }
        
        [SerializeField] private CharacterController characterController;

        public override void ResetEntity()
        {
            base.ResetEntity();
            reference.ResetReference();
        }

        public void SetupCharacter(CharacterInstruction instruction)
        {
            if (!string.IsNullOrEmpty(instruction.Name))
            {
                name = instruction.Name;
            }
            IsPlayable = instruction.IsPlayable;
            reference.physicalBody.SetupPhysicalBody(reference.transform, characterController);

            SetupEntity();
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
