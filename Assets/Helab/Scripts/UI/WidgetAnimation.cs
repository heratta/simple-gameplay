using System;
using System.Collections;
using Helab.Time;
using UnityEngine;

namespace Helab.UI
{
    public class WidgetAnimation : MonoBehaviour
    {
        [Serializable]
        private class AnimationSetting
        {
            public float duration;
            
            public float beginScale = 1f;
            
            public float endScale = 1f;
            
            public float beginAlpha = 1f;
            
            public float endAlpha = 1f;
            
            public Vector3 beginPosition;
            
            public Vector3 endPosition;

            public bool HasDiffScale => float.Epsilon < Math.Abs(beginScale - endScale);
            
            public bool HasDiffAlpha => float.Epsilon < Math.Abs(beginAlpha - endAlpha);
            
            public bool HasDiffPosition => float.Epsilon < Math.Abs(beginPosition.sqrMagnitude - endPosition.sqrMagnitude);
        }

        [SerializeField] private AnimationSetting openSetting;
        
        [SerializeField] private AnimationSetting closeSetting;

        public void StartOpenAnimation(AbstractWidget widget, Action onDidComplete)
        {
            StartAnimation(widget, openSetting, onDidComplete);
        }
        
        public void StartCloseAnimation(AbstractWidget widget, Action onDidComplete)
        {
            StartAnimation(widget, closeSetting, onDidComplete);
        }

        private void StartAnimation(AbstractWidget widget, AnimationSetting setting, Action onDidComplete)
        {
            StartCoroutine(Animation(widget, setting, onDidComplete));
        }
        
        private static IEnumerator Animation(AbstractWidget widget, AnimationSetting setting, Action onDidComplete)
        {
            var elapsedTime = 0f;
            while (elapsedTime < setting.duration)
            {
                var t = elapsedTime / setting.duration;
                if (setting.HasDiffScale)
                {
                    widget.content.localScale = Vector3.one * Mathf.Lerp(setting.beginScale, setting.endScale, t);
                }

                if (setting.HasDiffPosition)
                {
                    widget.content.localPosition = Vector3.Lerp(setting.beginPosition, setting.endPosition, t);
                }

                if (setting.HasDiffAlpha)
                {
                    widget.canvasGroup.alpha = Mathf.Lerp(setting.beginAlpha, setting.endAlpha, t);
                }

                elapsedTime += AppTime.DeltaTime;
                yield return null;
            }
            
            widget.content.localScale = Vector3.one * setting.endScale;
            widget.content.localPosition = setting.endPosition;
            widget.canvasGroup.alpha = setting.endAlpha;
            
            onDidComplete?.Invoke();
        }
    }
}
