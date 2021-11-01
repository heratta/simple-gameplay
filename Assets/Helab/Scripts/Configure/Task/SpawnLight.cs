using System.Collections;
using UnityEngine;

namespace Helab.Configure.Task
{
    public class SpawnLight : AbstractTask
    {
        [SerializeField] private Light prefab;
        
        protected override IEnumerator Execute()
        {
            worldSpawner.SpawnLight(prefab);
            yield return null;
        }
    }
}
