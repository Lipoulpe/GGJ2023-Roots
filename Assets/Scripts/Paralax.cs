using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    float _startPos;
    float _length;
    [SerializeField] GameObject _Cam;
    [SerializeField] private float _parallaxEffect;

    private void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (_Cam.transform.position.x * (1 - _parallaxEffect));
        float distance = (_Cam.transform.position.x * _parallaxEffect);

        transform.position = new Vector2(_startPos + distance,transform.position.y);

        if(temp > _startPos + _length)
        {
            _startPos += _length;
        }
        else if (temp < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
