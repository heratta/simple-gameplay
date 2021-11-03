using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Helab.Configure.Task;
using Helab.Management;
using UnityEngine;

namespace Helab.Configure
{
    public class Make : MonoBehaviour
    {
        [SerializeField] private List<AbstractTask> tasks;
        
        public bool IsCompleted { get; private set; }
        
        public void StartMake(WorldSpawner worldSpawner)
        {
            StartCoroutine(RunMake(worldSpawner));
        }

        private void Awake()
        {
            if (tasks.Count <= 0)
            {
                tasks.AddRange(GetComponentsInChildren<AbstractTask>());
            }
        }

        private IEnumerator RunMake(WorldSpawner worldSpawner)
        {
            foreach (var task in tasks)
            {
                task.WorldSpawner = worldSpawner;
                task.StartTask();
            }
            
            yield return new WaitUntil(IsCompletedTask);

            IsCompleted = true;
        }

        private bool IsCompletedTask()
        {
            return tasks.All(task => task.IsCompleted);
        }
    }
}
