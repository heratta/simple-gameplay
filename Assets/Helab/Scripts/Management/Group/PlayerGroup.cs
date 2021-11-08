using System.Collections.Generic;
using Helab.Entity.Character;
using Helab.Helper;
using UnityEngine;

namespace Helab.Management.Group
{
    public class PlayerGroup : MonoBehaviour
    {
        public bool IsEmpty => players.Count <= 0;

        public CharacterEntity Current => GetOrDefault.Fetch(players, _currentIndex);

        [SerializeField] private List<CharacterEntity> players;
        
        private int _currentIndex;

        public void Reset()
        {
            _currentIndex = 0;
        }

        public void AddPlayer(CharacterEntity player)
        {
            players.Add(player);
        }
        
        public void RemovePlayer(CharacterEntity player)
        {
            players.Remove(player);
        }

        public void Next()
        {
            var index = _currentIndex + 1;
            _currentIndex = players.Count <= index ? 0 : index;
        }
        
        public void Prev()
        {
            var index = _currentIndex - 1;
            _currentIndex = index < 0 ? players.Count - 1 : index;
        }
    }
}
