using System.Collections;
using Helab.Management;
using UnityEngine;

namespace Helab.Configure.Task
{
    public abstract class AbstractTask : MonoBehaviour
    {
        public bool IsCompleted { get; private set; }

        public WorldSpawner WorldSpawner { get; set; }

        public void StartTask()
        {
            StartCoroutine(RunTask());
        }

        private IEnumerator RunTask()
        {
            yield return StartCoroutine(Execute());
            IsCompleted = true;
        }

        protected abstract IEnumerator Execute();
    }
}
