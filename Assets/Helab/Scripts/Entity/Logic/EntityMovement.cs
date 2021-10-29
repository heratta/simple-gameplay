using System.Collections.Generic;
using System.Linq;
using Helab.Entity.Logic.Energy;
using UnityEditor;
using UnityEngine;

namespace Helab.Entity.Logic
{
    public class EntityMovement : MonoBehaviour
    {
        [SerializeField] private List<AbstractKineticEnergy> kineticEnergies = new List<AbstractKineticEnergy>();

        [SerializeField] private EntityBasicParam param;

        public void ResetMovement()
        {
            foreach (var energy in kineticEnergies)
            {
                energy.ResetKineticEnergy();
            }
        }

        public void UpdateMovement()
        {
            UpdateEnergy();
            param.deltaMovement = KineticEnergyUtil.AggregateDeltaMovement(kineticEnergies);
        }

        private void Awake()
        {
            if (kineticEnergies.Count <= 0)
            {
                kineticEnergies.AddRange(GetComponentsInChildren<AbstractKineticEnergy>());
            }
        }

        private void UpdateEnergy()
        {
            foreach (var energy in kineticEnergies)
            {
                if (!energy.enabled || !energy.gameObject.activeSelf)
                {
                    continue;
                }
                
                energy.UpdateKineticEnergy();
            }
        }
        
#if UNITY_EDITOR
        [ContextMenu("UpdateEnergy")]
        private void EditorUpdateEnergy ()
        {
            kineticEnergies = GetComponentsInChildren<AbstractKineticEnergy>().ToList();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}
