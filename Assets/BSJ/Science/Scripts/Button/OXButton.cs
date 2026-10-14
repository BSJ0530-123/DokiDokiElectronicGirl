using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiYeonShi.Button
{
    /// <summary>
    /// Ox 버튼에 붙이면 됨
    /// </summary>
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
