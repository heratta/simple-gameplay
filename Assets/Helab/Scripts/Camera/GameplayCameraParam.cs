using Helab.Entity;
using Helab.Input;
using UnityEngine;

namespace Helab.Camera
{
    public class GameplayCameraParam : MonoBehaviour
    {
        public Transform posture;

        public InputSource inputSource;
        
        public Transform followTarget;

        public AbstractEntity player;
    }
}
