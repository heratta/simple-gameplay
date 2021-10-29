using Helab.Time;
using UnityEngine;

namespace Helab.Simply
{
    public class SimpleRotator : MonoBehaviour
    {
        private Vector3 _beginEuler;
        
        private Vector3 _endEuler;

        private float _duration;

        private float _elapsedTime;

        public void Rotate(Vector3 euler, float duration)
        {
            RotateTo(transform.eulerAngles + euler, duration);
        }
        
        public void RotateTo(Vector3 euler, float duration)
        {
            if (duration <= 0f)
            {
                SetRotation(euler);
            }
            else
            {
                _beginEuler = transform.eulerAngles;
                _endEuler = euler;
                _duration = duration;
                _elapsedTime = 0f;
                
                AdjustEuler();
            }
        }

        private void Update()
        {
            if (_duration <= 0f)
            {
                return;
            }
            
            _elapsedTime += AppTime.DeltaTime;
            
            if (_elapsedTime < _duration)
            {
                SetRotation(Vector3.Lerp(_beginEuler, _endEuler, _elapsedTime / _duration));
            }
            else
            {
                SetRotation(_endEuler);
                
                _beginEuler = Vector3.zero;
                _endEuler = Vector3.zero;
                _duration = 0f;
                _elapsedTime = 0f;
            }
        }

        private void AdjustEuler()
        {
            if (180f < Mathf.Abs(_endEuler.x - _beginEuler.x))
            {
                _beginEuler.x -= 360f;
            }
            if (180f < Mathf.Abs(_endEuler.y - _beginEuler.y))
            {
                _beginEuler.y -= 360f;
            }
            if (180f < Mathf.Abs(_endEuler.z - _beginEuler.z))
            {
                _beginEuler.z -= 360f;
            }
        }

        private void SetRotation(Vector3 euler)
        {
            transform.rotation = Quaternion.Euler(euler);
        }
    }
}
