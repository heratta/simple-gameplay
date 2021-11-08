using Helab.Management;
using Helab.Management.Context;
using UnityEngine;

namespace Helab.Controller
{
    public abstract class AbstractController : MonoBehaviour
    {
        public GameplayContext gameplayContext;
        
        public void ManagedUpdate()
        {
            UpdateController();
        }

        protected abstract void UpdateController();
    }
}
