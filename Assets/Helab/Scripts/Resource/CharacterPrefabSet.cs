using System;
using Helab.Entity.Character;
using Helab.Entity.View;
using UnityEngine;

namespace Helab.Resource
{
    [Serializable]
    public struct CharacterPrefabSet : IPrefabSet
    {
        public bool IsValid => id != 0;
        
        public int Id => id;
            
        public int id;
        
        public CharacterEntity entity;

        public CharacterPhysicalBody physicalBody;

        public GameObject viewBody;

        public EntityAnimation viewAnimation;
    }
}
