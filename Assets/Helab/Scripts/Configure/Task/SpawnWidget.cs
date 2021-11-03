using System.Collections;
using Helab.UI;
using UnityEngine;

namespace Helab.Configure.Task
{
    public class SpawnWidget : AbstractTask
    {
        [SerializeField] private AbstractWidget prefab;
        
        protected override IEnumerator Execute()
        {
            WorldSpawner.SpawnWidget(prefab);
            yield return null;
        }
    }
}
