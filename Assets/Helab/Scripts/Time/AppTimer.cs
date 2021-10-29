using System;
using UnityEngine;

namespace Helab.Time
{
    public class AppTimer : MonoBehaviour
    {
        private float _durationInSeconds;

        private float _elapsedTimeInSeconds;

        private Action _onDidFinish;

        public void StartTimer(float durationInSeconds, Action onDidFinish)
        {
            _durationInSeconds = durationInSeconds;
            _onDidFinish = onDidFinish;
        }

        private void OnEnable()
        {
            _durationInSeconds = 0f;
            _elapsedTimeInSeconds = 0f;
            _onDidFinish = null;
        }

        private void Update()
        {
            if (_durationInSeconds <= _elapsedTimeInSeconds)
            {
                return;
            }
            
            _elapsedTimeInSeconds += AppTime.DeltaTime;
            if (_durationInSeconds <= _elapsedTimeInSeconds)
            {
                _onDidFinish?.Invoke();
            }
        }
    }
}
