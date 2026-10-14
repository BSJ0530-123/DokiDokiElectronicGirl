using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiYeonShi.Context
{
    public class ContextUI : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClick;

        [SerializeField] private TextMeshProUGUI nameTxt;
        [SerializeField] private TextMeshProUGUI contextTxt;
        
        public void Show(ContextSO context)
        {
            nameTxt.text = context.personName;
            contextTxt.text = context.content;
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        //클릭 받아주기
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}
