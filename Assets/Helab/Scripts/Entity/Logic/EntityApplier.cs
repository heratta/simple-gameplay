using System.Collections.Generic;
using System.Linq;
using Helab.Entity.Logic.Apply;
using UnityEditor;
using UnityEngine;

namespace Helab.Entity.Logic
{
    public class EntityApplier : MonoBehaviour
    {
        [SerializeField] private List<AbstractApply> applies;

        public void UpdateApplier()
        {
            foreach (var apply in applies)
            {
                apply.Apply();
            }
        }

        private void Awake()
        {
            if (applies.Count <= 0)
            {
                applies.AddRange(GetComponentsInChildren<AbstractApply>());
            }
        }
        
#if UNITY_EDITOR
        [ContextMenu("UpdateApply")]
        private void EditorUpdateApply ()
        {
            applies = GetComponentsInChildren<AbstractApply>().ToList();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}
