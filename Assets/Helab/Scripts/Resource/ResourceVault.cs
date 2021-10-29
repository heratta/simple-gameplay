using System.Collections.Generic;
using UnityEngine;

namespace Helab.Resource
{
    public class ResourceVault : MonoBehaviour
    {
        [SerializeField] private List<CharacterPrefabSet> characterPrefabs;

        public CharacterPrefabSet FindCharacterPrefabSet(int id)
        {
            return FindPrefabSet(characterPrefabs, id);
        }

        private T FindPrefabSet<T>(List<T> list, int id) where T : IPrefabSet
        {
            foreach (var prefabSet in list)
            {
                if (prefabSet.Id == id)
                {
                    return prefabSet;
                }
            }

            return default;
        }
    }
}
