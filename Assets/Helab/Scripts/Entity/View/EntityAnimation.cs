using Helab.Animation;
using Helab.Entity.Environs;
using UnityEngine;

namespace Helab.Entity.View
{
    public class EntityAnimation : MonoBehaviour
    {
        public EntityEnvirons environs;
        
        public PlayableAnimator playableAnimator;
        
        private string _currentAssetName;

        public void ResetAnimation()
        {
            environs = null;
            playableAnimator = null;
            _currentAssetName = "";
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
            
            if (_currentAssetName == assetName)
            {
                return;
            }

            if (playableAnimator.SetAnimation(assetName, isBlend))
            {
                _currentAssetName = assetName;
            }
        }
    }
}
