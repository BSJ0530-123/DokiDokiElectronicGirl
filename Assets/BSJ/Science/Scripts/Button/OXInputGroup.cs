using System;
using UnityEngine;

namespace MiYeonShi.Button
{
    public class OXInputGroup : MonoBehaviour
    {
        public event Action<OXEnum> OnSelected;

        [SerializeField] private OXButton[] buttons;

        private void OnEnable()
        {
            foreach (var button in buttons)
                button.OnClick += Forward;
        }

        private void OnDisable()
        {
            foreach (var button in buttons)
                button.OnClick -= Forward;
        }

        public void SetActive(bool active)
        {
            foreach (var button in buttons)
                button.gameObject.SetActive(active);
        }

        private void Forward(OXEnum ox)
        {
            OnSelected?.Invoke(ox);
        }
    }
}
