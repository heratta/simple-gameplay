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
            var entity = worldSpawner.SpawnStage(entityPrefab, viewBodyPrefab);
            entity.name = name;
            yield return null;
        }
    }
}
