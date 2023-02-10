using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSprite : MonoBehaviour
{
    [SerializeField] Image _Image;
    public Sprite[] Sprites;

    int _timerSwap = 24;
    int _spriteIndex = 0;

    private void FixedUpdate()
    {
        _timerSwap--;

        if(_timerSwap==0)
        {
            _timerSwap = 24;
            SwapSprite();
        }
        
    }

    void SwapSprite()
    {
        _Image.sprite = Sprites[_spriteIndex++ % Sprites.Length];
    }
}
