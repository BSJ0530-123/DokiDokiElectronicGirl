using System;
using MiYeonShi.Context;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiYeonShi.Button
{
    /// <summary>
    /// 순서대로 대본 플레이 역할만 해주는 애
    /// </summary>
    public class QuizDirector : MonoBehaviour
    {
        public event Action<bool> OnAnswered;
        public event Action OnFinished;

        [SerializeField] private ContextUI contextUI;
        [SerializeField] private OXInputGroup input;
        [SerializeField] private ContextSO[] contexts;

        private ContextSO _current;
        private int _index;
        private bool _waitingAnswer;

        private void Start()
        {
            StartContext();
        }

        private void OnEnable()
        {
            contextUI.OnClick += HandleBubbleClick;
            input.OnSelected += HandleSelected;
        }

        private void OnDisable()
        {
            contextUI.OnClick -= HandleBubbleClick;
            input.OnSelected -= HandleSelected;
        }
        
        [ContextMenu("Start Quiz")]
        public void StartContext()
        {
            _index = 0;
            ShowCurrent();
        }
        
        //현재 콘텍스트 보여주기
        private void ShowCurrent()
        {
            if (contexts == null || _index >= contexts.Length)
            {
                Finish();
                return;
            }

            _current = contexts[_index];
            _waitingAnswer = _current.isQuiz;
            input.SetActive(_current.isQuiz);
            contextUI.Show(_current);
        }
        
        //넘기기
        private void Next()
        {
            _index++;
            ShowCurrent();
        }
        
        //마치기
        private void Finish()
        {
            _current = null;
            _waitingAnswer = false;
            input.SetActive(false);
            contextUI.Hide();
            OnFinished?.Invoke();
        }
        
        //클릭 받기
        private void HandleBubbleClick()
        {
            if (_waitingAnswer)
                return;

            Next();
        }
        
        //답 선택 받기
        private void HandleSelected(OXEnum ox)
        {
            if (!_waitingAnswer)
                return;

            _waitingAnswer = false;
            OnAnswered?.Invoke(_current.answerIsCorrect == (ox == OXEnum.O));
            Next();
        }
    }
}
