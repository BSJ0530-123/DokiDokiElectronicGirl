using System;
using MiYeonShi.Context;
using MiYeonShi.Gauge;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace MiYeonShi.Button
{
    public class QuizDirector : MonoBehaviour
    {
        public event Action<bool> OnAnswered;
        public event Action OnFinished;

        [SerializeField] private ContextUI contextUI;
        [SerializeField] private OXInputGroup input;
        [SerializeField] private ContextSO[] contexts;
        private GaugeManager _gaugeManager;

        private ContextSO _current;
        private int _index;
        private bool _waitingAnswer;

        private void Awake()
        {
            _gaugeManager = GetComponentInChildren<GaugeManager>();
        }

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
            Debug.Log("Quiz Finished");

            if (!_gaugeManager.isClear || _gaugeManager.Current < _gaugeManager.max)
            {
                SceneManager.LoadScene("GameOver");
            }
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
