using UnityEngine;

namespace Helab.Entity.Logic.Module
{
    public abstract class AbstractModule : MonoBehaviour
    {
        public virtual void ResetModule()
        {
            
        }
        
        public abstract void UpdateModule();
    }
}
