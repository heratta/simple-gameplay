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

        public WorldSpawner worldSpawner;
        
        public void StartMake()
        {
            StartCoroutine(RunMake());
        }

        private void Awake()
        {
            if (tasks.Count <= 0)
            {
                tasks.AddRange(GetComponentsInChildren<AbstractTask>());
            }
        }

        private IEnumerator RunMake()
        {
            foreach (var task in tasks)
            {
                task.worldSpawner = worldSpawner;
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
