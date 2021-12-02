using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Helab.UI
{
    public class InteractiveBlocker : MonoBehaviour, IPointerClickHandler
    {
        public Action OnClick;

        public void ResetBlocker()
        {
            OnClick = null;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}
