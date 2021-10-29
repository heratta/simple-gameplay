using System.Collections.Generic;
using System.Linq;
using Helab.Entity.Logic.Module;
using UnityEditor;
using UnityEngine;

namespace Helab.Entity.Logic
{
    public class EntityModular : MonoBehaviour
    {
        [SerializeField] private List<AbstractModule> modules;

        public void ResetModular()
        {
            foreach (var module in modules)
            {
                module.ResetModule();
            }
        }

        public void UpdateModular()
        {
            foreach (var module in modules)
            {
                module.UpdateModule();
            }
        }

        private void Awake()
        {
            if (modules.Count <= 0)
            {
                modules.AddRange(GetComponentsInChildren<AbstractModule>());
            }
        }
        
#if UNITY_EDITOR
        [ContextMenu("UpdateModule")]
        private void EditorUpdateModule ()
        {
            modules = GetComponentsInChildren<AbstractModule>().ToList();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}
