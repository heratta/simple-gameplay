using System.Collections.Generic;
using UnityEngine;

namespace Helab.Entity.Logic.Energy
{
    public static class KineticEnergyUtil
    {
        public static Vector3 AggregateDeltaMovement(List<AbstractKineticEnergy> kineticEnergies)
        {
            var result = Vector3.zero;
            foreach (var energy in kineticEnergies)
            {
                result += energy.DeltaMovement;
            }

            return result;
        }
    }
}
