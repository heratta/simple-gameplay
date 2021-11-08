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

        public void SetViewBody(GameObject viewBody)
        {
            this.viewBody = viewBody;
            this.viewBody.transform.SetParent(transform, false);
        }

        public void SetViewAnimation(EntityAnimation viewAnimation)
        {
            this.viewAnimation = viewAnimation;
            this.viewAnimation.transform.SetParent(transform, false);
        }
        
        public void SetupView(EntityEnvirons environs)
        {
            if (viewAnimation != null)
            {
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
