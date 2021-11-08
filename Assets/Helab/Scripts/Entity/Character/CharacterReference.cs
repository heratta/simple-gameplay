using UnityEngine;

namespace Helab.Entity.Character
{
    public class CharacterReference : MonoBehaviour
    {
        public CharacterPhysicalBody physicalBody;

        public void ResetReference()
        {
            physicalBody = null;
        }

        public void SetPhysicalBody(CharacterPhysicalBody physicalBody)
        {
            this.physicalBody = physicalBody;
            this.physicalBody.transform.SetParent(transform, false);
        }
    }
}
