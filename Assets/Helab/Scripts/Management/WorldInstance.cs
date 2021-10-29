using Helab.ObjectPool;
using UnityEngine;

namespace Helab.Management
{
    public class WorldInstance
    {
        public int Key => GameObject.GetInstanceID();
        
        public GameObject GameObject;

        public Component Component;
        
        public GameObjectPool Pool;
    }
}
