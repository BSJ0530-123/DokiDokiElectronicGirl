using MiYeonShi.Button;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiYeonShi.Gauge
{
    public class AffectionScorer : MonoBehaviour
    {
        [SerializeField] private QuizDirector quizDirector;
        [SerializeField] private GaugeManager gauge;
        [Header("호감도 스택(5면 5번 문제맞추면 한칸 올라감")]
        [SerializeField] private int correctPerGauge = 5;

        private int _correctCount;

        private void OnEnable()
        {
            quizDirector.OnAnswered += HandleAnswered;
        }

        private void OnDisable()
        {
            quizDirector.OnAnswered -= HandleAnswered;
        }
        
        //맞았다는 신호 보내기
        private void HandleAnswered(bool correct)
        {
            if (!correct)
            {
                gauge.Decrease();
                Debug.Log("호감도 내려감");
                return;
            }
            
            Debug.Log("맞춰서, 스택 쌓임");

            _correctCount++;
            if (_correctCount < correctPerGauge)
                return;

            _correctCount = 0;
            gauge.Increase();
        }
    }
}
