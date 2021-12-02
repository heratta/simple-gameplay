using Helab.Animation;
using Helab.Entity.Environs;
using UnityEngine;

namespace Helab.Entity.View
{
    public class EntityAnimation : MonoBehaviour
    {
        public EntityEnvirons environs;
        
        public PlayableAnimator playableAnimator;
        
        public string CurrentAssetName { get; private set; }

        public void ResetAnimation()
        {
            environs = null;
            playableAnimator = null;
            CurrentAssetName = "";
            ResetProperty();
        }
        
        public virtual void StartAnimation()
        {
            
        }
        
        public virtual void UpdateAnimation()
        {
            
        }

        protected virtual void ResetProperty()
        {
            
        }

        protected void SetAnimation(string assetName, bool isBlend)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return;
            }
            
            if (CurrentAssetName == assetName)
            {
                return;
            }

            if (playableAnimator.SetAnimation(assetName, isBlend))
            {
                CurrentAssetName = assetName;
            }
        }
    }
}
