using Helab.Animation;
using Helab.Entity.Environs;
using UnityEngine;

namespace Helab.Entity.View
{
    public class EntityView : MonoBehaviour
    {
        public GameObject viewBody;
        
        public EntityAnimation viewAnimation;

        public void ResetView()
        {
            viewBody = null;
            if (viewAnimation != null)
            {
                viewAnimation.ResetAnimation();
                viewAnimation = null;
            }
        }
        
        public void SetupView(EntityEnvirons environs)
        {
            if (viewBody != null)
            {
                viewBody.transform.SetParent(transform, false);
            }

            if (viewAnimation != null)
            {
                viewAnimation.transform.SetParent(transform, false);
                viewAnimation.environs = environs;
                if (viewBody != null)
                {
                    viewAnimation.playableAnimator = viewBody.GetComponent<PlayableAnimator>();
                }

                viewAnimation.StartAnimation();
            }
        }
        
        public void UpdateView()
        {
            if (viewAnimation != null)
            {
                viewAnimation.UpdateAnimation();
            }
        }
    }
}
