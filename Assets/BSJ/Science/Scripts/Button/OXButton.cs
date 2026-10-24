using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiYeonShi.Button
{
    public class OXButton : MonoBehaviour, IPointerClickHandler
    {
        public OXEnum OX;

        public event Action<OXEnum> OnClick;
        
        //클릭 받아주기
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(OX);
        }
    }
}
