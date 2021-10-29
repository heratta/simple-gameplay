using System.Collections.Generic;
using Helab.Entity.Environs.State;
using UnityEngine;

namespace Helab.Entity.Environs
{
    public class EntityEnvirons : MonoBehaviour
    {
        [SerializeField] private List<AbstractState> states;
        
        public T GetState<T>() where T : class
        {
            foreach(var state in states)
            {
                if (state is T result)
                {
                    return result;
                }
            }

            return null;
        }

        public void ResetEnvirons()
        {
            foreach(var state in states)
            {
                state.ResetState();
            }
        }
        
        private void Awake()
        {
            if (states.Count <= 0)
            {
                states.AddRange(GetComponentsInChildren<AbstractState>());
            }
        }
    }
}
