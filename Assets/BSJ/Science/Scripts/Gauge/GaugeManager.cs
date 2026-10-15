using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MiYeonShi.Gauge
{
    /// <summary>
    /// 호감도 게이지 수치만 관리
    /// </summary>
    public class GaugeManager : MonoBehaviour
    {
        public event Action OnGaugeChanged;

        [SerializeField] private SpriteSwap spriteSwap;
        [SerializeField] private Slider gauge;
        [SerializeField] private GameObject _loveParticleSystem;
        [SerializeField] private ParticleSystem _loveEffect;
        private ParticleSystem.EmissionModule _loveEmission;

        public bool isClear = false;
        
        public int max = 5;

        public int _current;

        public int Max => max;
        public int Current => _current;

        public static GaugeManager Instance; 
        
        private void Awake()
        {
            _loveEmission = _loveEffect.emission;
            
            if (Instance != null)
                Destroy(gameObject);
            else
            {
                Instance = this;
            }
        }

        
        private void Start()
        {
            if (_loveEffect == null || _loveParticleSystem == null)
                return;
            _loveEmission.rateOverTime = 0;
        }

        private void Update()
        {
            if(Current == max)
                isClear =  true;

            if (isClear)
            {
                // 클리어 씬이동
            }
                
        }

        public void Increase()
        {
            Set(_current + 1);
            Debug.Log("한칸 올라감");
            StartCoroutine(LoveEffectCoroutine());
        }

        public void Decrease()
        {
            Set(_current - 1);
        }

        private void Set(int value)
        {
            _current = Mathf.Clamp(value, 0, max);
            Debug.Log($"z[{_current}] = {max}");
            gauge.value = (float)_current / max;
            spriteSwap.ChangeSprite();
            OnGaugeChanged?.Invoke();
        }

        IEnumerator LoveEffectCoroutine()
        {
            _loveEmission.rateOverTime = 20;
            yield return new WaitForSeconds(0.5f);
            _loveEmission.rateOverTime = 0;
        }
        
    }
}
