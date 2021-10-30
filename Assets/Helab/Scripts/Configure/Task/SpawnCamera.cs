using System.Collections;
using Helab.Camera;
using UnityEngine;

namespace Helab.Configure.Task
{
    public class SpawnCamera : AbstractTask
    {
        [SerializeField] private AbstractCamera prefab;
        
        protected override IEnumerator Execute()
        {
            worldSpawner.SpawnCamera(prefab);
            yield return null;
        }
    }
}
