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
    }
}
