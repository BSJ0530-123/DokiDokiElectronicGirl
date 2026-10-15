using System;
using MiYeonShi.Gauge;
using UnityEngine;

public class SpriteSwap : MonoBehaviour
{
    [SerializeField] Sprite[] _characterSprites;
    private SpriteRenderer _spriteRenderer;
    private GaugeManager _gaugeManager;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _gaugeManager = GaugeManager.Instance;
    }

    public void ChangeSprite()
    {
        if(_spriteRenderer.sprite == _characterSprites[2])
            return;
        if (_gaugeManager._current > _gaugeManager.max * 2 / 3)
        {
            _spriteRenderer.sprite = _characterSprites[2];
            Debug.Log("세번째 스프라이트");
        }

        else if (_gaugeManager._current > _gaugeManager.max * 1 / 3)
        {
            _spriteRenderer.sprite = _characterSprites[1];
            Debug.Log("두번째 스프라이트");
        }


    }
}
