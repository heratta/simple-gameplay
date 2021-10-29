using Helab.Resource;
using UnityEngine;

namespace Helab.Entity.Character
{
    public struct CharacterInstruction
    {
        public int Id;
        
        public bool IsPlayable;
        
        public string Name;
        
        public Vector3 Position;

        public CharacterPrefabSet PrefabSet;
    }
}
