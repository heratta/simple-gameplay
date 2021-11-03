using System.Collections;
using UnityEngine;

namespace Helab.Configure.Task
{
    public class SpawnLight : AbstractTask
    {
        [SerializeField] private Light prefab;
        
        protected override IEnumerator Execute()
        {
            WorldSpawner.SpawnLight(prefab);
            yield return null;
        }
    }
}
