using System;
using UnityEngine;

namespace Helab.Input
{
    public class InputSource : MonoBehaviour
    {
        public readonly InputValues<Vector3> Vector3Inputs = new InputValues<Vector3>();
        
        public readonly InputValues<float> FloatInputs = new InputValues<float>();
        
        public readonly InputValues<bool> BoolInputs = new InputValues<bool>();

        public bool GetInputBool<TKey>(TKey enumKey) where TKey : Enum
        {
            return BoolInputs.GetInput(enumKey);
        }

        private void LateUpdate()
        {
            Vector3Inputs.Clear();
            FloatInputs.Clear();
            BoolInputs.Clear();
        }
    }
}
