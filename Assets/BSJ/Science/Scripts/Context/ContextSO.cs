using UnityEngine;

namespace MiYeonShi.Context
{
    [CreateAssetMenu(fileName = "Context SO", menuName = "SO/Context", order = 0)]
    public class ContextSO : ScriptableObject
    {
        public string personName;
        [TextArea(10, 3)] public string content;
        
        public bool isQuiz;
        public bool answerIsCorrect;
    }
}