using System.Collections;
using Helab.Entity.Stage;
using UnityEngine;

namespace Helab.Configure.Task
{
    public class SpawnStage : AbstractTask
    {
        [SerializeField] private StageEntity entityPrefab;

        [SerializeField] private GameObject viewBodyPrefab;
        
        protected override IEnumerator Execute()
        {
            WorldSpawner.SpawnStage(entityPrefab, viewBodyPrefab, name);
            yield return null;
        }
    }
}
